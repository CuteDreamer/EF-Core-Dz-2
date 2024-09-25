using DbService;

namespace EF_Core_Dz_2
{
    internal class Program
    {
        private static OrderService orderService;
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                orderService = new OrderService();
                //orderService.EnsurePopulated();
                //AddOrder();
                GetOrder();
            }
        }

        static void AddOrder()
        {
            Order order = new Order
            {
                Fio = "Artem Karp",
                Address = "Odessa"
            };

            var milk = orderService.GetProduct(2);
            var apple = orderService.GetProduct(3);

            order.OrderLines.Add(new OrderLine { ProductId = milk.Id, Quantity = 2 });

            order.OrderLines.Add(new OrderLine { ProductId = apple.Id, Quantity = 2 });

            orderService.AddOrder(order);
        }

        private static void GetOrder()
        {
            int orderId = 1;
            var currentOrder = orderService.GetOrder(orderId);
            if (currentOrder != null)
            {
                Console.WriteLine(currentOrder);

            }
        }



    }
}
