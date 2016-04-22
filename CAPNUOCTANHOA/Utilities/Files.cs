using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using aejw.Network;

namespace CAPNUOCTANHOA.Utilities
{
    class Files
    {

        public static string LocalDirver = "";
        public static string pathShare = "";
        public static string UserName = "";
        public static string Password = "";
        public static string fileTemplate = "";
        public static string localSave = "";
        public static string createFile = "";
        public static string FileName = "";
        public static string numberRecord = "20";
        public static string pageSize = "A4";
        
        public static string[] getFileOnServer()
        {

            string line;
            string[] words = null;
            string[] arrFile = null;
            try
            {
                StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\app.conf");
                while ((line = sr.ReadLine()) != null)
                {
                    words = Regex.Split(line, ",");
                }
            }
            catch (Exception)
            {
            }
            if (words != null)
            {
                numberRecord = words[0];
                pageSize = words[1];

                //LocalDirver = words[0];
                //pathShare = words[1];
                //UserName = words[2];
                //Password = words[3];
                //fileTemplate = words[4];
                //localSave = words[5];
                //NetworkDrive oNetDrive = new aejw.Network.NetworkDrive();
                //try
                //{
                //    oNetDrive.LocalDrive = LocalDirver;
                //    oNetDrive.ShareName = pathShare;
                //    oNetDrive.MapDrive(UserName, Password);

                //}
                //catch (Exception )
                //{

                //}
                //oNetDrive = null;
                //arrFile = Directory.GetFiles(LocalDirver);
            }

            return arrFile;
        }

        public static bool CheckFile(string shs)
        {
            string[] arrFile = getFileOnServer();
            foreach (var item in arrFile)
            {
                if (item.Contains(shs))
                    return true;
            }
            return false;
        }

        public static bool CopyFile(string[] arrFile, string fileName, string folder, string newName)
        {
            //string[] arrFile = getFileOnServer();
            try
            {
                createFile = "";
                FileName = "";
                System.IO.Directory.CreateDirectory(localSave+ @"\" + folder);
                foreach (var item in arrFile)
                {
                    if (item.Contains(fileName))
                    {
                        File.Copy(item, (localSave + @"\" + folder + @"\" + newName + ".dwg"),true);
                        try
                        {

                            createFile = Regex.Split(item, "\\-")[1].Replace(".dwg", "");
                            createFile = createFile.Insert(2, "/");
                            createFile = createFile.Insert(5, "/");
                            FileName = newName + ".dwg";
                        }
                        catch (Exception)
                        {
                            
                        }
                        return true;
                    }
                }
            }
            catch (Exception)
            {
               
            }
           

            return false;
        }
    }
}