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
                var query1 = ctx.Employees
                    .Where(emp => emp.Department.Cities.Any(c => c.Name == "Chihuahua"))
                    .Select(p => p.FirstName);

                Console.WriteLine("Empleados cuyo departamento tenga una sede en Chihuahua:");
                foreach (var nombre in query1)
                {
                    Console.WriteLine(nombre);
                }

                //2. Listar todos los departamentos y el numero de empleados que pertenezcan a cada departamento.
                var query2 = from Department in ctx.Departments
                                                          join Employee in ctx.Employees
                                                          on Department.Id equals Employee.DepartmentId
                                                          into tablaQuery2
                                                          select new
                                                          {
                                                              dep = Department.Name,
                                                              emp = tablaQuery2.Count()
                                                          };


                Console.WriteLine("Numero de empleados que pertenezcan a cada departamento:");
                foreach (var list in query2)
                {

                    Console.WriteLine("El departamento: {0} tiene: {1} empleados", list.dep, list.emp);
                }
                 

                 //3. Listar todos los empleados remotos. Estos son los empleados cuya ciudad no se encuentre entre las sedes de su departamento.
                 var query3 = ctx.Employees
                     .Where(emp => emp.Department.Cities.All(cit => cit.Name != emp.City.Name))
                     .Select(p => p.FirstName);

                 Console.WriteLine("Eempleados cuya ciudad no se encuentre entre las sedes de su departamento:");
                 foreach (var nombre in query3)
                 {
                     Console.WriteLine(nombre);
                 }

                //4. Listar todos los empleados cuyo aniversario de contratación sea el próximo mes.
                DateTime nextMonth = DateTime.Today;
                nextMonth.AddMonths(1);

                var query4 = ctx.Employees
                    .Where(p => p.HireDate.Month == nextMonth.Month)
                    .Select(q => q.FirstName);

                Console.WriteLine("Empleados cuyo aniversario de contratación sea el próximo mes:");
                foreach (var nombre in query4)
                {
                    Console.WriteLine(nombre);
                }

                //5. Listar los 12 meses del año y el numero de empleados contratados por cada mes.
                var query5 = from Employee in ctx.Employees
                             group Employee by Employee.HireDate.Month into tablaQuery5
                             select new
                             {
                                 mes = tablaQuery5.FirstOrDefault().HireDate.Month,
                                 cant = tablaQuery5.Count()
                             };


                Console.WriteLine("Numero de empleados contratados por cada mes:");
                foreach (var list in query5)
                {
                    Console.WriteLine("En el mes: {0}  se contrataron: {1} empleados", list.mes, list.cant);
                }
            }

            Console.Read();
        }
    }
}