using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Product 的摘要说明
/// </summary>
public class Product
{
    public string Name { get; set; }
    public Category Category { get; set; }
    public override string ToString()
    {
        return Name;
    }
}