using DataAccess;


namespace Business_Tiier
{
    public class clsChef
    {

        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;
        public int ChefID { get; set; }
        public int PersonID { get; set; }
        public clsEmployee EmployeeInformation { get; set; }
        public string Specific { get; set; }
        public string Dogree { get; set; }
        public string Note { get; set; }
        public float Salary { get; set; }

        public clsChef()
        {
            this.ChefID = -1;
            this.PersonID = -1;
            this.Specific = "";
            this.Dogree = "";
            this.Note = "";
            this.Salary = 0;
            Mode = enMode.AddNew;

        
        }

        public clsChef(int ChefID, int PersonID, string Specific, string Dogree, string Note, float Salary)
        {
            this.ChefID = ChefID;
            this.PersonID =PersonID;
            this.Specific = Specific;
            this.Dogree = Dogree;
            this.Note = Note;
            this.Salary = Salary;
            this.EmployeeInformation = clsEmployee.FindEmployee(PersonID);
            Mode = enMode.Update;

        }


        private bool _AddNewChef()
        {
            this.ChefID = DataAccess.clsChef.AddNewChef(this.PersonID, this.Specific, this.Dogree, this.Note, this.Salary);
            return (this.ChefID != -1);
        
        }

        private bool _UpdateChef()
        {

            return DataAccess.clsChef.UpdateChef(this.ChefID, this.PersonID, this.Specific, this.Dogree, this.Note, this.Salary);
        }

        public static clsChef FindChefByChefID(int ChefID)
        {
            int PersonID = 0;
            string Specific = "", Dogree = "", Note = "";
            float Salary = 0;

            bool IsFound = DataAccess.clsChef.GetChefInformationByChefID(ChefID, ref PersonID, ref Specific, ref Dogree, ref Note, ref Salary);
            if (IsFound)
            {
                return new clsChef(ChefID, PersonID, Specific, Dogree, Note, Salary);
            }
            else
                return null;
        
        }


        public static clsChef FindChefByPersonID(int PersonID)
        {
            int ChefID = 0;
            string Specific = "", Dogree = "", Note = "";
            float Salary = 0;

            bool IsFound = DataAccess.clsChef.GetChefInformationByPersonID(PersonID, ref ChefID, ref Specific, ref Dogree, ref Note, ref Salary);
            if (IsFound)
            {
                return new clsChef(ChefID, PersonID, Specific, Dogree, Note, Salary);
            }
            else
                return null;

        }


        bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewChef())
                    {
                        Mode = enMode.Update;
                        return  true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateChef();
            }
            return false;
        }



    }
}
