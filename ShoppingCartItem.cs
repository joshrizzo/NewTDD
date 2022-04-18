namespace TDDRealWorld
{
    internal class ShoppingCartItem
    {
        public double Price { get; set; }
        public int Quantity { get; internal set; }
        public bool Taxable { get; internal set; }
    }
}