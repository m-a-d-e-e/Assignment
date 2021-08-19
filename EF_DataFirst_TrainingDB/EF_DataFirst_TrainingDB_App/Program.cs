using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DataFirst_TrainingDB_App
{
    class Program
    {
        static void Main(string[] args)
        {
            TRAININGEntities db = new TRAININGEntities();

            //1.LIST ALL THE DATA FROM THE EMPLOYEE TABLE

            IEnumerable<EMP> query1 = from e in db.EMPs select e;

            IEnumerable<EMP> query1M = db.EMPs.Select(e => e);

            //foreach (var item in query1M)
            //{
            //    Console.WriteLine(item.EMPNO +"\t"+ item.ENAME +"\t"+ item.JOB +"\t"+ item.MGR +"\t"+ item.HIREDATE +"\t"+ item.SAL +"\t"+ item.COMM +"\t"+ item.DEPTNO);
            //}


            //2. LIST ALL THE DATA FROM THE EMPLOYEE TABLE ORDER BY JOB

            IEnumerable<EMP> query2 = from e in db.EMPs orderby e.JOB select e;

            IEnumerable<EMP> query2M = db.EMPs.OrderBy(e => e.JOB);

            //foreach (var item in query2)
            //{
            //    Console.WriteLine(item.ENAME + "\t" + item.JOB);
            //}



            //3. LIST ALL THE DATA FROM THE EMPLOYEE TABLE WHOSE NAME
            //START WITH S

            IEnumerable<EMP> query3 = from e in db.EMPs where e.ENAME.StartsWith("s") select e;

            IEnumerable<EMP> query3M = db.EMPs.Where(e => e.ENAME.StartsWith("S"));

            //foreach (var item in query3M)
            //{
            //    Console.WriteLine(item.ENAME);
            //}


            //4. LIST DISTINCT JOB

            var query4 = (from e in db.EMPs select e.JOB).Distinct();

            var query4M = db.EMPs.Select(e => e.JOB).Distinct();

            //foreach(var item in query4M)
            //{
            //    Console.WriteLine(item);
            //}


            //5. FIND THE DETAILS OF ALL MANAGER (IN ANY DEPT) AND ALL
            //CLERKS IN DEPT 10

            IEnumerable<EMP> query5 = from e in db.EMPs where (e.JOB == "MANAGER" || (e.JOB == "CLERK" && e.DEPTNO == 10)) select e;

            IEnumerable<EMP> query5M = db.EMPs.Where(e => e.JOB == "Manager" || (e.JOB == "clerk" && e.DEPTNO == 10)  );

            //foreach (var item in query5M)
            //{
            //    Console.WriteLine($"{item.ENAME}\t{item.JOB}\t {item.DEPTNO} ");
            //}


            //6. FIND THE EMPLOYEES WHO DO NOT RECEIVE A COMMISSION

            IEnumerable<EMP> query6 = from e in db.EMPs where e.COMM == null select e;

            IEnumerable<EMP> query6M = db.EMPs.Where(e => e.COMM == null);


            //foreach (var item in query6M)
            //{
            //    Console.WriteLine(item.ENAME);
            //}


            //7. FIND ALL EMPLOYEES WHOSE NET EARNINGS (SAL + COMM) IS
            //GREATER THAN RS. 2000

            IEnumerable<EMP> query7 = from e in db.EMPs let NetEarnings = e.SAL + e.COMM where NetEarnings > 2000 select e;


            IEnumerable<EMP> query7M = db.EMPs.Where(e => e.COMM + e.SAL > 2000).Select(e => e);

            //foreach (var item in query7M)
            //{
            //    Console.WriteLine(item.ENAME + "\t" + item.SAL + "\t" + item.COMM );
            //}

            //8. FIND ALL EMPLOYEE HIRED IN MONTH OF FEBUARY (OF ANY YEAR)

            IEnumerable<EMP> query8 = from e in db.EMPs where e.HIREDATE.Value.Month.Equals(2) select e;

            IEnumerable<EMP> query8M = db.EMPs.Where(e => e.HIREDATE.Value.Month.Equals(2)).Select(e => e);


            //9.LIST TOTAL SALARY FOR THE ORGANIZATION

            var query9 = (from e in db.EMPs select e).Sum(e => e.SAL);
            var query9M = db.EMPs.Sum(e => e.SAL);

            //Console.WriteLine(query9M);

            //10. LIST TOTAL EMPLOYEES WORKS IN EACH DEPARTMENT

            var query10 = from e in db.EMPs
                          group e by e.DEPTNO into empGrp
                          select new
                          {
                              dept = empGrp.Key,
                              count = empGrp.Count()
                          };

            var query10M = db.EMPs.GroupBy(e => e.DEPTNO).Select(empgrp => new { dept = empgrp.Key, count = empgrp.Count() });


            //foreach(var item in query10M)
            //{
            //    Console.WriteLine(item.dept + "\t" + item.count);
            //}


            //11. LIST FIRST THREE HIGHEST PAID EMPLOYEES

            IEnumerable<EMP> query11 = (from e in db.EMPs orderby e.SAL descending select e).Take(3);

            IEnumerable<EMP> query11M = db.EMPs.OrderByDescending(e => e.SAL).Take(3);

            //foreach(EMP e in query11)
            //{
            //    Console.WriteLine(e.ENAME + "\t" + e.SAL);
            //}


            //12. DISPLAY THE NAMES, JOB AND SALARY OF ALL EMPLOYEES,
            //SORTED ON DESCENDING ORDER OF JOB AND WITHIN JOB,
            //SORTED ON THE DESCENDING ORDER OF SALARY

            var query12 = from e in db.EMPs orderby e.JOB descending, e.SAL descending select new { Name = e.ENAME, Job = e.JOB, Salary = e.SAL };

            var query12M = db.EMPs.OrderBy(e => e.JOB).ThenByDescending(e => e.SAL);

            //foreach(var item in query12M)
            //{
            //    Console.WriteLine(item.Name + "\t" + item.Job + "\t" + item.Salary);
            //}


            //13. LIST DEPARTMENT NAME, EMPLOYEE NAME AND JOB

            var query13 = from e in db.EMPs join d in db.DEPTs on e.DEPTNO equals d.DEPTNO select new { d.DNAME, e.ENAME, e.JOB };

            var query13M = db.EMPs.Join(db.DEPTs, e => e.DEPTNO, d => d.DEPTNO, (e, d) => new { d.DNAME, e.ENAME, e.JOB });

            //foreach (var item in query13M)
            //{
            //    Console.WriteLine(item.DNAME + "\t" + item.ENAME + "\t" + item.JOB);
            //}

            //14. LIST DEPARTMENT NAME AND MAX SALARY FOR EACH DEPARTMENT

            var query14 = from e in db.EMPs
                          join d in db.DEPTs on e.DEPTNO equals d.DEPTNO
                          group e by d.DNAME into grp
                          select new { Department = grp.Key, MaxSal = grp.Max(e => e.SAL) };

            var query14M = db.EMPs.Join(db.DEPTs, e => e.DEPTNO, d => d.DEPTNO, (e, d) => new { d.DNAME, e.SAL }).
                            GroupBy(d => d.DNAME).Select(grp => new { Department = grp.Key, MaxSal = grp.Max(e => e.SAL) });

            //foreach (var item in query14M)
            //{
            //    Console.WriteLine(item.Department + " " + item.MaxSal);
            //}

            //15. LIST DEPARTMENT NAME AND TOTAL EMPLOYEE WORKING IN EACH
            //DEPARTMENT ALSO INCLUDE DEPARTMENT WHERE NO EMPLOYEES
            //ARE WORKING

            var query15 = from d in db.DEPTs
                          join e in db.EMPs on d.DEPTNO equals e.DEPTNO into ed
                          from e in ed.DefaultIfEmpty()
                          group e by d.DNAME into grp
                          select new { Dept = grp.Key, TotalEmp = grp.Count() };

            
            var query15M = db.DEPTs.GroupJoin(db.EMPs, d => d.DEPTNO, e => e.DEPTNO, (d, e) => new { dept=d, emp=e }).GroupBy(d => d.dept.DNAME).Select(grp => new { Dept = grp.Key, TotalEmp = grp.Count() });


            //foreach (var item in query15M)
            //{
            //    Console.WriteLine(item.Dept + "\t" + item.TotalEmp);
            //}


            //16. SELECT Dept Name FROM Department TABLE
            //WHILE DISPLAYING DATA ALSO DISPLAY Emp Name BASED ON Department

            var query16 = from d in db.DEPTs
                          join e in db.EMPs on d.DEPTNO equals e.DEPTNO into ed
                          from e in ed.DefaultIfEmpty()
                          group e by d.DNAME into grp
                          select grp;



            //foreach (var item in query16)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach (var v in item)
            //    {
            //        Console.WriteLine("\t\t" + v);
            //    }
            //}


            //17. INSERT NEW DEPARTMENT AND EMPLOYEE FOR THAT DEPARTMENT DEPTNO = 50, DEPTNAME = IT
            //EMPNO = 1001, EMPNAME = RAHUL

            //Console.WriteLine("before insert : Dept->" + db.DEPTs.Count() + "\tEmp->" + db.EMPs.Count());
            //DEPT newdept = new DEPT()
            //{
            //    DEPTNO = 60,
            //    DNAME = "IT"
            //};

            //db.DEPTs.Add(newdept);
            //db.SaveChanges();
            //EMP newemp = new EMP()
            //{
            //    EMPNO = 1001,
            //    ENAME = "RAHUL"
            //};

            //db.EMPs.Add(newemp);
            //db.SaveChanges();

            //Console.WriteLine("After insert : Dept->" + db.DEPTs.Count() + "\tEmp->" + db.EMPs.Count());



            //18. UPDATE Rahul RECORD WITH SAL = 20000

            //EMP updEmp = db.EMPs.SingleOrDefault(e => e.ENAME == "RAHUL");
            //if (updEmp != null)
            //{
            //    updEmp.SAL = 20000;

            //    int count = db.SaveChanges();
            //    Console.WriteLine($"{count} record updated");
            //}

            //19.Delete Record of Rahul

            //EMP delemp = db.EMPs.SingleOrDefault(e => e.ENAME == "RAHUL");
            //if (delemp != null)
            //{
            //    db.EMPs.Remove(delemp);
            //    db.SaveChanges();
            //    Console.WriteLine("Employee deleted");
            //}
            //else
            //{
            //    Console.WriteLine("Employee not found");
            //}


            //20. Write a stored procedure in SQL Server name it as
            //JobWiseDetails which takes Job as in parameter and
            //return Total Employee, Max Salary and Min Salary for the Job


            //ObjectParameter cnt = new ObjectParameter("emp", typeof(int));
            //ObjectParameter mn = new ObjectParameter("min", typeof(decimal));
            //ObjectParameter mx = new ObjectParameter("max", typeof(decimal));
            //db.JobWiseDetails("MANAGER", cnt, mx, mn);
            //Console.WriteLine("Total employees : " + cnt.Value);
            //Console.WriteLine("Max salary : " + mx.Value);
            //Console.WriteLine("Min salary : " + mx.Value);


            Console.ReadLine();


        }
    }
}








