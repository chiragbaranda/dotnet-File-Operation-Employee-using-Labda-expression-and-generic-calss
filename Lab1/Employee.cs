///
/// Program: Employee Class
/// 
/// Author: Chirag Baranda
/// 000759867
/// Date:   23 November 2018
/// I, Chirag Baranda, 000759867 certify that this material is my original work. No other person's work has been used without due acknowledgement.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// This class describes the employee
/// </summary>
public class Employee : IComparable<Employee>
{
  

    /// <summary>
    /// get and Set Properties for The employee name
    /// </summary>
    /// <returns> The employee name </returns>
    public string Name{ get; set; }

    /// <summary>
    /// get and Set Properties for employee ID
    /// </summary>
    /// <returns> Employee ID </returns>
    public int Number { get; set; }

    /// <summary>
    /// get and Set Properties for hours
    /// </summary>
    /// <returns> Employee ID </returns>
    public Double Hours { get; set; }


    /// <summary>
    /// get and Set Properties for Hourly rate
    /// </summary>
    /// <returns>Hourly rate of the week</returns>
    public decimal Rate { get; set; }
    /// <summary>
    /// get and Set Properties for Hours 
    /// </summary>
    /// <returns>Hours of the week</returns>
    

    public decimal gross;

    /// <summary>
    /// Gross pay get ans Set Property
    /// </summary>
    /// <returns>calculated Gross pay for the week</returns>
    public decimal Gross { get { return Gross; } set {  this.Gross = (Hours < 40) ? (decimal)Hours * Rate : (40.0m * Rate) + (((decimal)Hours - 40.0m) * Rate * 1.5m); } }

    /// <summary>
    /// Default constructor for Employee - used for creating Employee array
    /// </summary>
    public Employee()
  {
  }

  /// <summary>
  /// Four-argument constructor for Employee
  /// </summary>
  /// <param name="name">Employee name</param>
  /// <param name="number">Employee number</param>
  /// <param name="rate">Hourly rate of pay</param>
  /// <param name="hours">Hours worked in a week</param>
  public Employee(string name, int number, decimal rate, double hours)
  {
        /* This is the better way to set data in a class - use the accessor methods.
         * That way, if their implementation changes, the constructor doesn't need to
         * be edited as well.
         */
        this.Name = name;
        this.Number = number;
        this.Rate = rate;
        this.Hours = hours;
        this.Gross = Gross;
  }

  

  /// <summary>
  /// Employee display method - in the future, we'll override the ToString method of Object
  /// </summary>
  public override String ToString() => $"{Name,-20}  {Number:D5}  {Rate,6:C}  {Hours:#0.00}  {Gross,9:C}";

    public int CompareTo(Employee other , EmployeeDataComparer.ComparisonType which)
    {
        switch(which)
        {
            case EmployeeDataComparer.ComparisonType.Name: return this.Name.CompareTo(other.Name);
            case EmployeeDataComparer.ComparisonType.Number: return this.Number.CompareTo(other.Number);
            case EmployeeDataComparer.ComparisonType.Hours: return this.Hours.CompareTo(other.Hours);
            case EmployeeDataComparer.ComparisonType.Rate: return this.Rate.CompareTo(other.Rate);
            case EmployeeDataComparer.ComparisonType.Gross: return this.Gross.CompareTo(other.Gross);
        }
        return 0;
    }

    public static EmployeeDataComparer GetDataComparer()
    {
        return new EmployeeDataComparer();
    }

    public int CompareTo(Employee other)
    {
        return this.Name.CompareTo(other.Name);
    }




    public class EmployeeDataComparer : IComparer<Employee>
    {   /// <summary>
        /// 
        /// </summary>
        public EmployeeDataComparer.ComparisonType WhichComparison
        { get { return WhichComparison; } set { this.WhichComparison = WhichComparison; } }
        /// <summary>
        /// Creating types using Enumarator
        /// which will be used as a type for comparison
        /// </summary>
        public enum ComparisonType
        {
            Name,
            Number,
            Rate,
            Hours,
            Gross
        };
        /// <summary>
        /// Compare method for comapring two Employee object
        /// </summary>
        /// <param name="empData1"></param>
        /// <param name="empData2"></param>
        /// <returns>0 - If less than 0, x is less than y | -If 0, x equals y | -if greater than 0, x is greater than y.</returns>
        public int Compare(Employee empData1, Employee empData2)
        {
            return empData1.CompareTo(empData2, WhichComparison);
        }

    }  
}