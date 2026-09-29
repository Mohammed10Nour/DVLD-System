using DVLD_Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DVLD.Class_Global
{
    public class clsGlobal
    {
        public static clsUser CurrentUser;

        static string KeyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\CurrentUserData";
       
        static string ValueName = "UserData";
        static string ValueData = " ";
        public static void StoreDataInFile(string UserName, string Password,bool chkRememberMe)
        {
            try
            {
                if (chkRememberMe)
                {
                    ValueData = UserName + "##" + Password;
                    Registry.SetValue(KeyPath, ValueName, ValueData, RegistryValueKind.String);
                }
                else
                {
                    ValueData = "";
                    Registry.SetValue(KeyPath, ValueName, ValueData, RegistryValueKind.String);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
         
        }
        public static bool GetDataFromFile(ref string UserName,ref string Password)
        {
            
            string ValueData = "";
            try
            {
                  ValueData = Registry.GetValue(KeyPath, ValueName, null) as string;
                if (!string.IsNullOrEmpty(ValueData))
                {
                    int pos = ValueData.IndexOf("##");
                    UserName = ValueData.Substring(0, pos);
                    Password = ValueData.Substring(pos + 2);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
                
            }
        }
    }
}
