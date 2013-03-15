using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Employee 的摘要说明
/// </summary>
public class Employee
{
    private List<Employee> _subordinates = new List<Employee>();

    public string Name { get; set; }
    public Employee ReportsTo { get; private set; }
    public IEnumerable<Employee> Subordinates { get { return _subordinates; } }

    public void AddSubordinate(Employee employee)
    {
        _subordinates.Add(employee);
        employee.ReportsTo = this;
    }

    public override string ToString()
    {
        return Name;
    }
}