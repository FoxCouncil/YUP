using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Ca.Magrathean.Yup.DB
{
    public class SettingsDatabase
    {
        #region Constants
        public const string m_dbName = "Settings";
        public const string m_dbExtension = ".db";
        #endregion

        #region Private Fields
        bool m_firstRun = false;
        static SQLiteConnection m_sql;
        static bool m_threadRunning = false;
        static Queue<SetSettingsData> m_saveSettingsBuffer = new Queue<SetSettingsData>();
        static Thread m_settingsConsumerThread = new Thread(new ThreadStart(SettingsConsumer));
        #endregion

        #region Constructor
        public SettingsDatabase()
        {
            string dbFileName = YUP.UserDocuments + @"\settings" + m_dbExtension;

            m_firstRun = !File.Exists(dbFileName);

            m_sql = new SQLiteConnection("Data Source=" + dbFileName + ";");
            m_sql.Open();

            if (m_firstRun)
            {
                CreateSettingsTable();
            }

            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            m_threadRunning = true;
            m_settingsConsumerThread.Start();
        }
        #endregion

        #region Settings Get Methods
        public string GetStringSetting(string name)
        {
            using (SQLiteDataReader _reader = FetchRow(name))
            {
                if (_reader.HasRows)
                {
                    _reader.Read();
                    return _reader.GetString(1);
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public int? GetIntegerSetting(string name)
        {
            using (SQLiteDataReader _reader = FetchRow(name))
            {
                if (_reader.HasRows)
                {
                    _reader.Read();
                    return _reader.GetInt32(2);
                }
                else
                {
                    return null;
                }
            }
        }

        public bool? GetBoolSetting(string name)
        {
            using (SQLiteDataReader _reader = FetchRow(name))
            {
                if (_reader.HasRows)
                {
                    _reader.Read();
                    return bool.Parse(_reader.GetString(3));
                }
                else
                {
                    return null;
                }
            }
        }

        public Color GetColorSetting(string name)
        {
            using (SQLiteDataReader _reader = FetchRow(name))
            {
                if (_reader.HasRows)
                {
                    _reader.Read();
                    return Color.FromArgb(_reader.GetInt32(4), _reader.GetInt32(5), _reader.GetInt32(6));
                }
                else
                {
                    return Color.Empty;
                }
            }
        }

        public Size GetSizeSetting(string name)
        {
            using (SQLiteDataReader _reader = FetchRow(name))
            {
                if (_reader.HasRows)
                {
                    _reader.Read();
                    return new Size(_reader.GetInt32(7), _reader.GetInt32(8));
                }
                else
                {
                    return Size.Empty;
                }
            }
        }

        public Point GetPointSetting(string name)
        {
            return new Point(GetSizeSetting(name));
        }
        #endregion

        #region Settings Set Methods
        public void SetStringSetting(string name, string value)
        {
            SaveSetting(new SetSettingsData(SettingsDataType.String, name, (object)value));
        }

        public void SetIntegerSetting(string name, int value)
        {
            SaveSetting(new SetSettingsData(SettingsDataType.Integer, name, (object)value));
        }

        public void SetBoolSetting(string name, bool value)
        {
            SaveSetting(new SetSettingsData(SettingsDataType.Bool, name, (object)value));
        }

        public void SetColorSetting(string name, Color value)
        {
            SaveSetting(new SetSettingsData(SettingsDataType.Color, name, (object)value));
        }

        public void SetSizeSetting(string name, Size value)
        {
            SaveSetting(new SetSettingsData(SettingsDataType.Size, name, (object)value));
        }

        public void SetPointSetting(string name, Point value)
        {
            SaveSetting(new SetSettingsData(SettingsDataType.Point, name, (object)value));
        }
        #endregion

        #region Utility Methods
        void Application_ApplicationExit(object sender, EventArgs e)
        {
            m_threadRunning = false;
        }

        private static void SettingsConsumer()
        {
            try
            {
                while (m_threadRunning)
                {
                    while (m_saveSettingsBuffer.Count != 0)
                    {
                        SetSettingsData saveData = m_saveSettingsBuffer.Dequeue();

                        switch (saveData.Type)
                        {
                            case SettingsDataType.Bool:
                                SettingsDatabase.SaveBoolSetting(saveData.Name, Convert.ToBoolean(saveData.Value));
                            break;

                            case SettingsDataType.Color:
                                SettingsDatabase.SaveColorSetting(saveData.Name, (Color)saveData.Value);
                            break;

                            case SettingsDataType.Integer:
                                SettingsDatabase.SaveIntegerSetting(saveData.Name, (int)saveData.Value);
                            break;

                            case SettingsDataType.Point:
                                SettingsDatabase.SaveSizeSetting(saveData.Name, new Size((Point)saveData.Value));
                            break;

                            case SettingsDataType.Size:
                                SettingsDatabase.SaveSizeSetting(saveData.Name, (Size)saveData.Value);
                            break;

                            case SettingsDataType.String:
                                SettingsDatabase.SaveStringSetting(saveData.Name, (string)saveData.Value);
                            break;
                        }
                    }

                    Thread.Sleep(10);
                }
            }
            catch (ThreadAbortException)
            {
                m_threadRunning = false;
                return;
            }
        }

        private static bool SaveSizeSetting(string name, Size value)
        {
            using (SQLiteCommand _query = m_sql.CreateCommand())
            {
                _query.CommandText = "REPLACE INTO " + m_dbName + "(settingName, settingVecX, settingVecY) VALUES ('" + name + "', " + value.Width.ToString() + ", " + value.Height.ToString() + ")";

                int rowsChanged = _query.ExecuteNonQuery();

                if (rowsChanged != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private static bool SaveColorSetting(string name, Color value)
        {
            using (SQLiteCommand _query = m_sql.CreateCommand())
            {
                _query.CommandText = "REPLACE INTO " + m_dbName + "(settingName, settingColorRed, settingColorGreen, settingColorBlue) VALUES('" + name + "', " + value.R.ToString() + ", " + value.G.ToString() + "," + value.B.ToString() + ")";

                int rowsChanged = _query.ExecuteNonQuery();

                if (rowsChanged != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private static bool SaveBoolSetting(string name, bool value)
        {
            using (SQLiteCommand _query = m_sql.CreateCommand())
            {
                _query.CommandText = "REPLACE INTO " + m_dbName + "(settingName, settingBool) VALUES('" + name + "', '" + value.ToString() + "')";

                int rowsChanged = _query.ExecuteNonQuery();

                return (rowsChanged != 0);
            }
        }

        private static bool SaveIntegerSetting(string name, int value)
        {
            using (SQLiteCommand _query = m_sql.CreateCommand())
            {
                _query.CommandText = "REPLACE INTO " + m_dbName + "(settingName, settingInt) VALUES('" + name + "', " + value.ToString() + ")";

                int rowsChanged = _query.ExecuteNonQuery();

                if (rowsChanged != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private static bool SaveStringSetting(string name, string value)
        {
            using (SQLiteCommand _query = m_sql.CreateCommand())
            {
                _query.CommandText = "REPLACE INTO " + m_dbName + "(settingName, settingString) VALUES('" + name + "', '" + value + "')";

                int rowsChanged = _query.ExecuteNonQuery();

                if (rowsChanged != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void SaveSetting(SetSettingsData data)
        {
            if (!m_saveSettingsBuffer.Contains(data))
            {
                m_saveSettingsBuffer.Enqueue(data);
            }
        }
        
        private SQLiteDataReader FetchRow(string name)
        {
            using (SQLiteCommand _query = m_sql.CreateCommand())
            {
                _query.CommandText = "SELECT * FROM " + m_dbName + " WHERE settingName = '" + name + "'";

                return _query.ExecuteReader();
            }
        }

        private void CreateSettingsTable()
        {
            using (SQLiteCommand _query = m_sql.CreateCommand())
            {
                _query.CommandText = "CREATE TABLE " + m_dbName + " (settingName TEXT UNIQUE, settingString TEXT, settingInt INTEGER, settingBool TEXT, settingColorRed INTEGER, settingColorGreen INTEGER, settingColorBlue INTEGER, settingVecX INTEGER, settingVecY INTEGER, settingVecZ INTEGER)";
                _query.ExecuteNonQuery();
            }
        }
        #endregion

        #region Public Properties
        public bool FirstRun
        {
            get 
            { 
                return m_firstRun; 
            }
        }
        #endregion
    }

    public struct SetSettingsData
    {
        public SetSettingsData(SettingsDataType type, string name, object value)
        {
            Type = type;
            Name = name;
            Value = value;
        }

        public SettingsDataType Type;
        public string Name;
        public object Value;
    }

    public enum SettingsDataType
    {
        Bool,
        String,
        Integer,
        Color,
        Size,
        Point
    }
}
