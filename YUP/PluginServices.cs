using System;
using System.IO;
using System.Reflection;
using Ca.Magrathean.Yup.Yum;
using System.Windows.Forms;

namespace Ca.Magrathean.Yup 
{
	/// <summary>
	/// Summary description for PluginServices.
	/// </summary>
	public class PluginServices : IModuleHost
	{
        private Types.AvailablePlugins m_colAvailablePlugins = new Types.AvailablePlugins();

        #region Constructor
        /// <summary>
		/// Constructor of the Class
		/// </summary>
		public PluginServices()
		{
            FindPlugins();
        }
        #endregion

        #region Public Methods
        /// <summary>
		/// Searches the Application's Startup Directory for Plugins
		/// </summary>
		public void FindPlugins()
		{
			FindPlugins(Application.StartupPath + @"\Plugins");
		}

		/// <summary>
		/// Searches the passed Path for Plugins
		/// </summary>
		/// <param name="path">Directory to search for Plugins in</param>
		public void FindPlugins(string path)
		{
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

			//First empty the collection, we're reloading them all
			m_colAvailablePlugins.Clear();
		
			//Go through all the files in the plugin directory
			foreach (string fileOn in Directory.GetFiles(path))
			{
				FileInfo file = new FileInfo(fileOn);
				
				//Preliminary check, must be .dll
				if (file.Extension.Equals(".dll"))
				{	
					//Add the 'plugin'
					this.AddPlugin(fileOn);				
				}
			}
		}
		
		/// <summary>
		/// Unloads and Closes all AvailablePlugins
		/// </summary>
		public void ClosePlugins()
		{
			foreach (Types.AvailablePlugin pluginOn in m_colAvailablePlugins)
			{
				//Close all plugin instances
				//We call the plugins Dispose sub first incase it has to do 
				//Its own cleanup stuff
				pluginOn.Instance.Dispose(); 
				
				//After we give the plugin a chance to tidy up, get rid of it
				pluginOn.Instance = null;
			}
			
			//Finally, clear our collection of available plugins
			m_colAvailablePlugins.Clear();
        }

        public bool CheckURL(string url)
        {
            IModule module;
            return CheckURL(url, out module);
        }

        public bool CheckURL(string url, out IModule foundPlugin)
        {
            foreach (Types.AvailablePlugin plugin in AvailablePlugins)
            {
                if (plugin.Instance.CheckURL(url))
                {
                    foundPlugin = plugin.Instance;
                    return true;
                }
            }

            foundPlugin = null;
            return false;
        }
        #endregion

        #region Private Methods
        private void AddPlugin(string FileName)
		{
			//Create a new assembly from the plugin file we're adding..
			Assembly pluginAssembly = Assembly.LoadFrom(FileName);
			
			//Next we'll loop through all the Types found in the assembly
			foreach (Type pluginType in pluginAssembly.GetTypes())
			{
				if (pluginType.IsPublic) //Only look at public types
				{
					if (!pluginType.IsAbstract)  //Only look at non-abstract types
					{
						//Gets a type object of the interface we need the plugins to match
						Type typeInterface = pluginType.GetInterface("IModule", true);
						
						//Make sure the interface we want to use actually exists
						if (typeInterface != null)
						{
							//Create a new available plugin since the type implements the IPlugin interface
							Types.AvailablePlugin newPlugin = new Types.AvailablePlugin();
							
							//Set the filename where we found it
							newPlugin.AssemblyPath = FileName;
							
							//Create a new instance and store the instance in the collection for later use
							//We could change this later on to not load an instance.. we have 2 options
							//1- Make one instance, and use it whenever we need it.. it's always there
							//2- Don't make an instance, and instead make an instance whenever we use it, then close it
							//For now we'll just make an instance of all the plugins
                            newPlugin.Instance = (IModule)Activator.CreateInstance(pluginAssembly.GetType(pluginType.ToString()));
							
							//Set the Plugin's host to this class which inherited IPluginHost
							newPlugin.Instance.Host = this;

							//Call the initialization sub of the plugin
                            newPlugin.Instance.Initialize();
							
							//Add the new plugin to our collection here
							this.m_colAvailablePlugins.Add(newPlugin);
							
							//cleanup a bit
							newPlugin = null;
						}	
						
						typeInterface = null; //Mr. Clean			
					}				
				}			
			}
			
			pluginAssembly = null; //more cleanup
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// A Collection of all Plugins Found and Loaded by the FindPlugins() Method
        /// </summary>
        public Types.AvailablePlugins AvailablePlugins
        {
            get
            {
                return m_colAvailablePlugins;
            }

            set
            {
                m_colAvailablePlugins = value;
            }
        }
        #endregion
    }

	namespace Types
	{
		/// <summary>
		/// Collection for AvailablePlugin Type
		/// </summary>
		public class AvailablePlugins : System.Collections.CollectionBase
		{			
			/// <summary>
			/// Add a Plugin to the collection of Available plugins
			/// </summary>
			/// <param name="pluginToAdd">The Plugin to Add</param>
			public void Add(Types.AvailablePlugin pluginToAdd)
			{
				this.List.Add(pluginToAdd); 
			}
		
			/// <summary>
			/// Remove a Plugin to the collection of Available plugins
			/// </summary>
			/// <param name="pluginToRemove">The Plugin to Remove</param>
			public void Remove(Types.AvailablePlugin pluginToRemove)
			{
				this.List.Remove(pluginToRemove);
			}
		
			/// <summary>
			/// Finds a plugin in the available Plugins
			/// </summary>
			/// <param name="pluginNameOrPath">The name or File path of the plugin to find</param>
			/// <returns>Available Plugin, or null if the plugin is not found</returns>
			public Types.AvailablePlugin Find(string pluginNameOrPath)
			{
				Types.AvailablePlugin toReturn = null;
			
				//Loop through all the plugins
				foreach (Types.AvailablePlugin pluginOn in this.List)
				{
					//Find the one with the matching name or filename
					if ((pluginOn.Instance.Name.Equals(pluginNameOrPath)) || pluginOn.AssemblyPath.Equals(pluginNameOrPath))
					{
						toReturn = pluginOn;
						break;		
					}
				}
				return toReturn;
			}
		}
		
		/// <summary>
		/// Data Class for Available Plugin.  Holds and instance of the loaded Plugin, as well as the Plugin's Assembly Path
		/// </summary>
		public class AvailablePlugin
		{
			//This is the actual AvailablePlugin object.. 
			//Holds an instance of the plugin to access
			//ALso holds assembly path... not really necessary
			private IModule myInstance = null;
			private string myAssemblyPath = "";

            public IModule Instance
			{
				get 
                {
                    return myInstance;
                }

				set
                {
                    myInstance = value;
                }
			}

			public string AssemblyPath
			{
				get 
                {
                    return myAssemblyPath;
                }

				set 
                {
                    myAssemblyPath = value;
                }
			}
		}
	}	
}

