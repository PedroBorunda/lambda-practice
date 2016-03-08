using lamda_practice.Data;
using System;
using System.Globalization;
using System.Linq;

namespace lambda_practice
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var ctx = new DatabaseContext())
            {
                //1. Listar todos los empleados cuyo departamento tenga una sede en Chihuahua
                IQueryable<string> query1 = ctx.Employees
                    .Where(emp => emp.Department.Cities.Equals("Chihuahua"))
                    .Select(p => p.FirstName);

                Console.WriteLine("Empleados cuyo departamento tenga una sede en Chihuahua:");
                foreach (string nombre in query1)
                {
                    Console.WriteLine(nombre);
                }

                //2. Listar todos los departamentos y el numero de empleados que pertenezcan a cada departamento.
                int fin = 0, hr = 0, it = 0, qty = 0, pro = 0, sup = 0;

                IQueryable<string> query2 = ctx.Employees
                     .Select(q => q.Department.Name);

                Console.WriteLine("Numero de empleados que pertenezcan a cada departamento:");
                foreach (string departamento in query2)
                {
                    switch (departamento)
                    {
                        case "Finances":
                            fin = fin + 1;
                            break;
                        case "HR":
                            fin = fin + 1;
                            break;
                        case "IT":
                            fin = fin + 1;
                            break;
                        case "Quality":
                            fin = fin + 1;
                            break;
                        case "Production":
                            fin = fin + 1;
                            break;
                        case "Support Center":
                            fin = fin + 1;
                            break;
                    }
                }

                Console.WriteLine("Finances: " + fin);
                Console.WriteLine("HR: " + hr);
                Console.WriteLine("IT: " + it);
                Console.WriteLine("Quality: " + qty);
                Console.WriteLine("Production: " + pro);
                Console.WriteLine("Support Center: " + sup);

                //3. Listar todos los empleados remotos. Estos son los empleados cuya ciudad no se encuentre entre las sedes de su departamento.
                IQueryable<string> query3 = ctx.Employees
                    .Where(emp => emp.Department.Cities.Contains(emp.City))
                    .Select(p => p.FirstName);

                Console.WriteLine("Eempleados cuya ciudad no se encuentre entre las sedes de su departamento:");
                foreach (string nombre in query3)
                {
                    Console.WriteLine(nombre);
                }

                //4. Listar todos los empleados cuyo aniversario de contratación sea el próximo mes.
                DateTime nextMonth = DateTime.Today;
                nextMonth.AddMonths(1);

                IQueryable<string> query4 = ctx.Employees
                    .Where(p => p.HireDate.Month == nextMonth.Month)
                    .Select(q => q.FirstName);

                Console.WriteLine("Empleados cuyo aniversario de contratación sea el próximo mes:");
                foreach (string nombre in query4)
                {
                    Console.WriteLine(nombre);
                }

                //5. Listar los 12 meses del año y el numero de empleados contratados por cada mes.
                int ene = 0, feb = 0, mar = 0, abr = 0, may = 0, jun = 0, jul = 0, ago = 0, sep = 0, oct = 0, nov = 0, dic = 0;


                IQueryable<DateTime> query5 = ctx.Employees
                    .Select(q => q.HireDate);

                Console.WriteLine("Numero de empleados contratados por cada mes:");
                foreach (DateTime mes in query5)
                {
                    switch (mes.Month)
                    {
                        case 1:
                            ene = ene + 1;
                            break;
                        case 2:
                            feb = feb + 1;
                            break;
                        case 3:
                            mar = mar + 1;
                            break;
                        case 4:
                            abr = abr + 1;
                            break;
                        case 5:
                            may = may + 1;
                            break;
                        case 6:
                            jun = jun + 1;
                            break;
                        case 7:
                            jul = jul + 1;
                            break;
                        case 8:
                            ago = ago + 1;
                            break;
                        case 9:
                            sep = sep + 1;
                            break;
                        case 10:
                            oct = oct + 1;
                            break;
                        case 11:
                            nov = nov + 1;
                            break;
                        case 12:
                            dic = dic + 1;
                            break;
                    }
                }

                Console.WriteLine("Enero: " + ene);
                Console.WriteLine("Febrero: " + feb);
                Console.WriteLine("Marzo: " + mar);
                Console.WriteLine("Abril: " + abr);
                Console.WriteLine("Mayo: " + may);
                Console.WriteLine("Junio: " + jun);
                Console.WriteLine("Julio: " + jul);
                Console.WriteLine("Agosto: " + ago);
                Console.WriteLine("Septiembre: " + sep);
                Console.WriteLine("Octubre: " + oct);
                Console.WriteLine("Noviembre: " + nov);
                Console.WriteLine("Diciembre: " + dic);
            }

            Console.Read();
        }
    }
}
