using System.Collections.Generic;

namespace OrderTracker.Models
{
  public class Order
  {
    public string Item { get; set;}
    public string Quantity { get; set;}
    public string Price { get; set;}
    public string DateOrdered { get; set;}
    public string DateShipped { get; set;}
    public int Id { get; }
    private static List<Order> _instances = new List<Order> {}; 

    public Order(string item, string quantity, string price, string dateOrdered, string dateShipped)
    {
      Item = item;
      Quantity = quantity;
      Price = price;
      DateOrdered = dateOrdered;
      DateShipped = dateShipped;
      _instances.Add(this);
      Id = _instances.Count;
    }
    public static List<Order> GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Order Find(int searchId)
    {
      return _instances[searchId-1];
    }
    
  }
}