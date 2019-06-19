using System;
using System.Collections;
using System.Collections.Generic;

namespace CarParking
{
    public class Employee
    {
         public Queue<bool> q = new Queue<bool>(3);
        public  static bool[] floaters = new bool[2];
       public  static bool[] ground = new bool[2];
        int employeeid;
                                  
         string carType;
         int slot;

        public  int GetId()
        {
            return this.employeeid;
        }

        public int GetSlot()
        {
            return this.slot;
        }

        public string GetCarType()
        {
            return this.carType;
        }

        public Employee(int employeeid,string carType,bool history,bool flag)
         {
            this.employeeid = employeeid;
            this.carType = carType;
            q.Enqueue(history);
            slot = GetSlotNumber(flag, carType);
        }

        public Employee()
        {

        }

        public static void ResetAll()
        {
            for(int i=0;i<2;i++)
            {
                floaters[i] = false;
                ground[i] = false;
            }
        }

    

        public static int GetSlotNumber(bool flag, string carType)
        {
            if(flag)
            {
                if(carType=="g")
                {
                    for(int i=0;i<2;i++)
                    {
                        if(ground[i]==false)
                        {
                            ground[i] = true;
                            return i;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (floaters[i] == false)
                        {
                            floaters[i] = true;
                            return i;
                        }
                    }
                }
            }
            return -1;
        }
    }



    class Program
    {
        
        static Dictionary<int, Employee> addEmployee = new Dictionary<int, Employee>();
        static Dictionary<int, Employee> waitingList = new Dictionary<int, Employee>();
        static Dictionary<int, Employee> allEmployees = new Dictionary<int, Employee>();
        public static string CheckIn(int employeeId)
        {
            Employee e=new Employee();
            allEmployees.TryGetValue(employeeId,out e);
            int slot=e.GetSlot();
            string carTpe = e.GetCarType();
            if (slot!=-1) {
                if (carTpe.Equals("g"))
                {
                    Employee.ground[slot] = true;
                   
                }
                else 
            {
                    Employee.floaters[slot] = true;
                }
                if (e.q.Count == 3)
                {
                    e.q.Dequeue();
                    e.q.Enqueue(true);
                }
            }
            else
            {
                if (carTpe.Equals("g"))
                {
                    Employee
                    Array.
                }

            }

        }
        static int count_ground=0,count_floater=0;
        static void Main(string[] args)
        {
            int employeeId;
            string carType;
            int slot;
            bool flag;
            int priority=0;
            while (true) {
                Console.WriteLine("Enter your Choice:\n1.AddEmploy:\n2.Display:\n3.Display Waiting list\n4.Chnage Day:\n5.Check In\n6.Exit");
                int choice =int.Parse(Console.ReadLine());
                Console.WriteLine(choice);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter your id:");
                        employeeId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter your Cartype(F/G):");
                        carType = Console.ReadLine().ToLower();
                        Console.WriteLine("Do you want a fixed slot (True/False):");
                        flag = Convert.ToBoolean(Console.ReadLine());
                        try
                        {
                            if(carType=="g" && count_ground<2)
                            {
                                addEmployee.Add(employeeId, new Employee(employeeId, carType, true, flag));
                                allEmployees.Add(employeeId, new Employee(employeeId, carType, true, flag));
                                count_ground++;
                            }
                            else if(carType == "f" && count_floater < 2)
                            {
                                addEmployee.Add(employeeId, new Employee(employeeId, carType, true, flag));
                                allEmployees.Add(employeeId, new Employee(employeeId, carType, true, flag));
                                count_floater++;
                            }
                            else
                            {
                                waitingList.Add(priority, new Employee(employeeId, carType, true, flag));
                                allEmployees.Add(employeeId, new Employee(employeeId, carType, true, flag));
                                priority++;
                            }
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine("User already Exists");
                        }
                        break;
                    case 2:
                        foreach (KeyValuePair<int, Employee> item in addEmployee)
                        {
                            Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value);
                        }
                        break;
                    case 3:
                        foreach (KeyValuePair<int, Employee> item in waitingList)
                        {
                            Console.WriteLine("Key: {0}, Value: {1}", item.Key, item.Value.GetId());
                        }
                        break;
                    case 4:
                        addEmployee.Clear();
                        waitingList.Clear();
                        Employee.ResetAll();
                        break;
                    case 5:
                        Console.WriteLine("Enter employee id:");
                        int temp = Convert.ToInt32(Console.ReadLine());
                        CheckIn(temp);
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("invalid ");
                        break;
                }
                 }
        }
    }
}
