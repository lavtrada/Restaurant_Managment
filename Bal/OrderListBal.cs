using FoodApp.Areas.Cart.Models;
using FoodApp.Areas.Item.Models;
using FoodApp.Areas.OrderList.Models;
using FoodApp.Dal;

namespace FoodApp.Bal;

public class OrderListBal
{
    private OrderListDal orderListDal;

    public OrderListBal()
    {
        orderListDal = new OrderListDal();
    }

    // #region SelectAllMenuItems
    //
    // public List<Item> SelectAllMenuItems()
    // {
    //     try
    //     {
    //         List<Item> orderLists = orderListDal.InsertInOrderList();
    //         return orderLists;
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //         throw;
    //     }
    // }
    //
    // #endregion

    // #region Restaurant Wise OrderList
    //
    // public List<OrderList> SelectAllOrders()
    // {
    //
    //     try
    //     {
    //         return orderListDal.SelectAllOrders();
    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e);
    //         throw;
    //     }
    //     
    // }
    //
    // #endregion

    #region Insert into orderlist

    public bool InsertInOrderList()
    {
        try
        {
            return orderListDal.InsertInOrderList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion
}