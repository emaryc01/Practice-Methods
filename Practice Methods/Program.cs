using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Demonstrates how methods may interact with each other via parameters and return statements.
 Shows how initialisation and method calls can be used both for single objects and for arrays of objects
 Emer Campbell
 2018*/

namespace Practice_Methods
{
    class Assessments
    {
        public Boolean Validate_Percentages(int amark)//accepts an assessment mark as a parameter and validates it in the range 1-100
        {
            if (amark > -1 && amark < 101)
                return true;
            else
                return false;
        }

        public int overall_mark(int exam, int cwk)/*In order to calculate an overall mark, the coursework and exam marks must be combined with a weighting of 
                                                   40% and 60% respectively*/
        {
            int overall = (int)(double)((exam * 0.6) + (cwk * 0.4));//appropriate weighting applied
            return overall;//calculated mark returned
        }

        public char grade(int overall) //grade boundary applied to overall mark
        {
            char grade = ' ';
            if (overall >= 90)
                grade = 'A';
            else if (overall >= 80)
                grade = 'B';
            else if (overall >= 70)
                grade = 'C';
            else if (overall >= 60)
                grade = 'D';
            else if (overall >= 50)
                grade = 'E';
            else if (overall >= 40)
                grade = 'F';
            else 
                grade = 'U';

            return grade;

        }

        public int getmark(string type)//Assessment types(exam or coursework) accepted as a parameter
        {
            //Mark accepted from the user.  Mark is validated by ValidatePercentages and result stored
            int grade = 0;
            Console.WriteLine(" Please enter a percentage mark for the {0}", type);
            grade = Int32.Parse(Console.ReadLine());
            bool isvalid = Validate_Percentages(grade);/*notice that methods in a class don't need to be called from a main method.  
                                                         They can also be called from inside another method in the class*/
            
            //If validation result is false, the user is asked for the result again
            while (isvalid == false)
            {
                Console.WriteLine("Your mark must be in the range 0-100");
                Console.WriteLine(" Please enter a percentage mark for the {0}", type);
                grade = Int32.Parse(Console.ReadLine());
                isvalid = Validate_Percentages(grade);
            }
            
            return grade;
        }

          static void Main(string[] args)
        {

            Assessments A = new Assessments();//A single exam object is created and appropriate methods called
            int exam_mark = A.getmark("exam");
            int cwk_mark = A.getmark("coursework");
            int overallmark = A.overall_mark(exam_mark, cwk_mark);
            char grade = A.grade(overallmark);

            Console.WriteLine("Your exam mark is {0}, your coursework mark is {1}, your overall mark is {2} and your grade is {3}", exam_mark, cwk_mark, overallmark, grade);


            Assessments[] AA = new Assessments[5];//Array of exam objects created
            int[] emark = new int[5];//arrays to hold returned values for each object
            int[] cmark = new int[5];
            int[] omark = new int[5];
            char[] ograde = new char[5];

            for (int i = 0; i < 5; i++)//loops through each item in object array
            {
                AA[i] = new Assessments();//Each object in array is initialised
                emark[i] = AA[i].getmark("exam");//appropriate methods called for each array item object
                cmark[i] = AA[i].getmark("coursework");
                omark[i] = AA[i].overall_mark(exam_mark, cwk_mark);
                ograde[i] = AA[i].grade(overallmark);

            Console.WriteLine("Your exam mark is {0}, your coursework mark is {1}, your overall mark is {2} and your grade is {3}", emark[i], cmark[i], omark[i], ograde[i]);

            }
            Console.WriteLine("Thank you");
            Console.ReadLine();


            
        }
    }
}
