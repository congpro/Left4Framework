using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Category 的摘要说明
/// </summary>
public class Category
{
    public string Name { get; set; }
    public override string ToString()
    {
        return Name;
    }
}