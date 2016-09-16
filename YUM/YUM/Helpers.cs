using System;
using System.Collections.Generic;
using System.Text;

namespace Ca.Magrathean.Yup.Yum
{
    #region Static URL Helpers
    /// <summary>
    /// Static URL String Helpers
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Parse a standard string to a escaped string.
        /// </summary>
        /// <param name="string2escape">The string to be escaped.</param>
        /// <returns>Escaped string.</returns>
        public static string URLEscapeString(string string2escape)
        {
            string escapedString = string.Empty;

            foreach (char character in string2escape.ToCharArray())
            {
                string string2add;

                switch (character)
                {
                    case '$':
                    {
                        string2add = "%24";
                    }
                    break;

                    case '-':
                    {
                        string2add = "%2D";
                    }
                    break;

                    case '_':
                    {
                        string2add = "%5F";
                    }
                    break;

                    case '.':
                    {
                        string2add = "%2E";
                    }
                    break;

                    case '+':
                    {
                        string2add = "%2B";
                    }
                    break;

                    case '!':
                    {
                        string2add = "%21";
                    }
                    break;

                    case '*':
                    {
                        string2add = "%2A";
                    }
                    break;

                    case '%':
                    {
                        string2add = "%25";
                    }
                    break;

                    case '"':
                    {
                        string2add = "%22";
                    }
                    break;

                    case '\'':
                    {
                        string2add = "%27";
                    }
                    break;

                    case '(':
                    {
                        string2add = "%28";
                    }
                    break;

                    case ')':
                    {
                        string2add = "%29";
                    }
                    break;

                    case ';':
                    {
                        string2add = "%3B";
                    }
                    break;

                    case '/':
                    {
                        string2add = "%2F";
                    }
                    break;

                    case '?':
                    {
                        string2add = "%3F";
                    }
                    break;

                    case ':':
                    {
                        string2add = "%3A";
                    }
                    break;

                    case '@':
                    {
                        string2add = "%40";
                    }
                    break;

                    case '=':
                    {
                        string2add = "%3D";
                    }
                    break;

                    case '&':
                    {
                        string2add = "%26";
                    }
                    break;

                    case '|':
                    {
                        string2add = "%7C";
                    }
                    break;

                    default:
                    {
                        string2add = character.ToString();
                    }
                    break;
                }

                escapedString += string2add;
            }

            return escapedString;
        }

        /// <summary>
        /// Parse an escaped string to a standard string.
        /// </summary>
        /// <param name="urlEncodedString">Escaped string to be reverted.</param>
        /// <returns>Unescaped string.</returns>
        public static string URLUnEscapeString(string urlEncodedString)
        {
            return urlEncodedString.Replace("%24", "$").Replace("%2D", "-").Replace("%2D", "_").Replace("%2E", ".").Replace("%2B", "+").Replace("%21", "!").Replace("%2A", "*").Replace("%25", "%").Replace("%22", "\"").Replace("%27", "'").Replace("%28", "(").Replace("%29", ")").Replace("%3B", ";").Replace("%2F", "/").Replace("%3F", "?").Replace("%3A", ":").Replace("%40", "@").Replace("%3D", "=").Replace("%26", "&").Replace("%7C", "|");
        }
    }
    #endregion

    #region Url Class
    /// <summary>
    /// Parses a given string representation of a URL into its components and optionally reassembles 
    /// these components back to a string representation.
    /// </summary>
    public sealed class Url
    {
        #region Private Members
        /// <summary>
        /// A string array of common protocol names.
        /// </summary>
        private string[] m_protocols = new string[] { "ftp", "ssh", "telnet", "smtp", "gopher", "http", "pop3", "nntp", "news", "https" };

        /// <summary>
        /// A integer array of common protocol port numbers.
        /// </summary>
        private int[] m_ports = new int[] { 21, 22, 23, 25, 70, 80, 110, 119, 119, 443 };

        /// <summary>
        /// Holds the value of the Protocol property.
        /// </summary>
        private string m_Protocol;

        /// <summary>
        /// Holds the value of the Host property.
        /// </summary>
        private string m_Host;

        /// <summary>
        /// Holds the value of the Port property.
        /// </summary>
        private int m_Port;

        /// <summary>
        /// Holds the value of the Username property.
        /// </summary>
        private string m_Username;

        /// <summary>
        /// Holds the value of the Password property.
        /// </summary>
        private string m_Password;

        /// <summary>
        /// Holds the value of the Path property.
        /// </summary>
        private string m_Path;

        /// <summary>
        /// Holds the value of the Query property.
        /// </summary>
        private string m_Query;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new Url instance.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <exception cref="ArgumentNullException"><paramref name="url"/> is a null reference.</exception>
        /// <exception cref="ArgumentException"><paramref name="url"/> is invalid.</exception>
        public Url(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException();
            }

            int pos = url.IndexOf("://", 0);

            if (pos <= 0)
            {
                throw new ArgumentException("The specified URL is invalid.");
            }

            Protocol = url.Substring(0, pos);

            url = url.Substring(pos + 3);

            // get query string
            pos = url.IndexOf("?");

            if (pos < 0)
            {
                Query = "";
            }
            else
            {
                Query = url.Substring(pos + 1);
                url = url.Substring(0, pos);
            }

            // get host [+port/user/pass]
            string[] parts;

            pos = url.IndexOf("/");

            if (pos < 0)
            {
                Path = "";
                parts = GetUrlParts(url);
            }
            else
            {
                Path = url.Substring(pos);
                parts = GetUrlParts(url.Substring(0, pos));
            }

            Username = parts[0];

            Password = parts[1];

            Host = parts[2];

            try
            {
                Port = int.Parse(parts[3]);
                if (Port == 0)
                {
                    Port = GetDefaultPort(Protocol);
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException("The specified port is invalid.", e);
            }
        }
        #endregion

        #region Url Private Methods
        /// <summary>
        /// Returns a default port number for well known algorithms.
        /// </summary>
        /// <param name="protocol">The protocol.</param>
        /// <returns>A number that corresponds to the default port of the given protocol -or- zero if the protocol is unknown.</returns>
        private int GetDefaultPort(string protocol)
        {
            int index = Array.IndexOf(m_protocols, protocol.ToLower(), 0, m_protocols.Length);

            if (index == -1)
            {
                return 0; // not a default protocol
            }
            else
            {
                return m_ports[index];
            }
        }

        /// <summary>
        /// Extracts the username, password, hostname and port from a partial URL.
        /// </summary>
        /// <param name="url">The partial URL to use.</param>
        /// <returns>An array of Strings that contain the username, password, hostname and port (in that order).</returns>
        /// <exception cref="ArgumentException">The specified URL is invalid.</exception>
        private string[] GetUrlParts(string url)
        {
            string[] ret = new string[4];
            string up;
            string hp; // user/pass and host/port

            int pos = url.IndexOf("@");

            if (pos < 0)
            {
                up = "";
                hp = url;
            }
            else
            {
                up = url.Substring(0, pos);
                hp = url.Substring(pos + 1);
            }

            // extract username/password
            pos = up.IndexOf(":");

            if (pos < 0)
            {
                ret[0] = up;
                ret[1] = "";
            }
            else
            {
                ret[0] = up.Substring(0, pos);
                ret[1] = up.Substring(pos + 1);
            }

            if (ret[1] != "" && ret[0] == "")
            {
                throw new ArgumentException("The specified URL is invalid.");
            }

            // extract host/port
            pos = hp.IndexOf(":");

            if (pos < 0)
            {
                ret[2] = hp;
                ret[3] = "0";
            }
            else
            {
                ret[2] = hp.Substring(0, pos);
                ret[3] = hp.Substring(pos + 1);
            }

            if (ret[2].Length == 0)
            {
                throw new ArgumentException("The specified URL is invalid.");
            }

            return ret;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Holds the protocol of the URL.
        /// </summary>
        /// <value>A <see cref="String"/> representing the protocol of the URL.</value>
        /// <exception cref="ArgumentNullException">The specified value is a null reference.</exception>
        public string Protocol
        {
            get
            {
                return m_Protocol;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                m_Protocol = value;
            }
        }

        /// <summary>
        /// Holds the host of the URL.
        /// </summary>
        /// <value>A <see cref="String"/> representing the host of the URL.</value>
        /// <exception cref="ArgumentNullException">The specified value is a null reference.</exception>
        public string Host
        {
            get
            {
                return m_Host;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                m_Host = value;
            }
        }

        /// <summary>
        /// Holds the port of the URL.
        /// </summary>
        /// <value>An <see cref="Int32"/> representing the port of the URL.</value>
        /// <remarks>This value is equal to zero if no port is specified.</remarks>
        /// <exception cref="ArgumentNullException">The specified value is a null reference.</exception>
        public int Port
        {
            get
            {
                return m_Port;
            }
            set
            {
                m_Port = value;
            }
        }

        /// <summary>
        /// Holds the username of the URL.
        /// </summary>
        /// <value>A <see cref="String"/> representing the username of the URL.</value>
        /// <remarks>This property can return an empty string.</remarks>
        /// <exception cref="ArgumentNullException">The specified value is a null reference.</exception>
        public string Username
        {
            get
            {
                return m_Username;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                m_Username = value;
            }
        }

        /// <summary>
        /// Holds the password of the URL.
        /// </summary>
        /// <value>A <see cref="String"/> representing the password of the URL.</value>
        /// <remarks>This property can return an empty string.</remarks>
        /// <exception cref="ArgumentNullException">The specified value is a null reference.</exception>
        public string Password
        {
            get
            {
                return m_Password;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                m_Password = value;
            }
        }

        /// <summary>
        /// Holds the path of the URL.
        /// </summary>
        /// <value>A <see cref="String"/> representing the path of the URL.</value>
        /// <remarks>This property can return an empty string.</remarks>
        /// <exception cref="ArgumentNullException">The specified value is a null reference.</exception>
        public string Path
        {
            get
            {
                return m_Path;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException();
                m_Path = value;
            }
        }

        /// <summary>
        /// Holds the query string of the URL.
        /// </summary>
        /// <value>A <see cref="String"/> representing the query string of the URL.</value>
        /// <remarks>This property can return an empty string.</remarks>
        /// <exception cref="ArgumentNullException">The specified value is a null reference.</exception>
        public string Query
        {
            get
            {
                return m_Query;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                m_Query = value;
            }
        }
        #endregion

        #region Object Method Override
        /// <summary>
        /// Returns a String that represents the current URL.
        /// </summary>
        /// <returns>Returns a String that represents the current URL.</returns>
        public override string ToString()
        {
            string user = "";
            string host = Host;
            string query = "";

            if (Username != "")
            {
                user += Username;
            }

            if (Password != "")
            {
                user += ":" + Password;
            }

            if (user != "")
            {
                user += "@";
            }

            if (Port != 0)
            {
                host += ":" + Port.ToString();
            }

            if (Query != "")
            {
                query += "?" + Query;
            }

            return Protocol + "://" + user + host + Path + query;
        }
        #endregion
    }
    #endregion
}
