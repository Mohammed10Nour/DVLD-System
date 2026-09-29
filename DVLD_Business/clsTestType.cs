using DVLD_DataAccess;
using System.Data;

namespace DVLD_Business
{
    public class clsTestType
    {
        public enum enMode { AddNew = 0,Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 };
       
        public enTestType ID = enTestType.VisionTest; 
        
       
        public string Title { get; set; }
        public string Description { get; set; }
        public float Fees { get; set; }

        public clsTestType ()
        {
            this.ID = enTestType.VisionTest;
            this.Title = "";
            this.Description = "";
            this.Fees = 0;
            Mode = enMode.AddNew;
        }
        private clsTestType(enTestType ID , string TestTitle, string TestDescription, float TestFees)
        {
            this.ID = ID;
            this.Description = TestDescription;
            this.Title = TestTitle;
            this.Fees = TestFees;
            Mode = enMode.Update;
        }
        private bool _AddNewTestType()
        {
            //call DataAccess Layer 

            this.ID = (clsTestType.enTestType)clsTestTypesData.AddNewTestType(this.Title, this.Description, this.Fees);

            return (this.Title != "");
        }

        private bool _UpdateTestType()
        {
            //call DataAccess Layer 

            return clsTestTypesData.UpdateTestType((int)this.ID, this.Title, this.Description, this.Fees);
        }

        public static clsTestType Find(clsTestType.enTestType TestTypeID)
        {
            string Title = "", Description = ""; float Fees = 0;
          
            if (clsTestTypesData.FindTestTypeInfoByID((int)TestTypeID, ref Title, ref Description, ref Fees))

                return new clsTestType(TestTypeID, Title, Description, Fees);
            else
                return null;

        }

        public static DataTable GetAllTestTypes()
        {
            return clsTestTypesData.GetAllTestTypes();

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestType();

            }

            return false;
        }
        public static int NumberOfPassedExams(int LDLApp_ID)
        {
            return clsTestTypesData.NumberOfPassedExams(LDLApp_ID);
        }
    }
}
       
    
