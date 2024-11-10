using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class ListSys
    {
        /*This variable just tracks the amount of objects created subtracted by 2, then i use the index to create IDs, making it easier to delete.*/
        static public int GlobalIndexCounter = 0;
        //Don't ask wtf i have done, i know theres better ways to do it, but im too lazy;

        public bool IsDone = false;
        public String ObjectiveName;
        public String ObjectiveDesc;
        public String CreationDateAndTime;

        public int index;

        public ListSys(String ObjName, String ObjDesc, String CreateDateAndTime, int index)
        {
            ObjectiveName = ObjName;
            ObjectiveDesc = ObjDesc;
            CreationDateAndTime = CreateDateAndTime;

            GlobalIndexCounter++;
            this.index = index;

        }
        void done()
        {
            IsDone = true;

        }




    }
    public abstract class UtilityChars 
    {
        public static string DoneASCII(bool done) 
        {
            if (done)
            {
                return "[X]";
            }
            else
            {
                return "[ ]";
            }
        }
    }

}

