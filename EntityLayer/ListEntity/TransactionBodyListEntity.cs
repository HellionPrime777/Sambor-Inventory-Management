namespace EntityLayer
{
    public class TransactionBodyListEntity
    {
        /// <summary>
        /// Цей клас дозволяє зберігати і отримувати дані про тіла транзакцій та пов'язані з ними продукти в рамках списку. 
        /// Він може бути корисним для організації та збереження даних про транзакції та пов'язані з ними продукти у структурованому форматі.
        /// </summary>

        public TransactionBodyListEntity() { }
        public TransactionBodyListEntity(TransactionBodyEntity body, ProductEntity product) 
            :this()
        {
            Body = body;
            Product = product;
        }
        public TransactionBodyEntity Body { get; set; }
        public ProductEntity Product { get; set; }

    }
}
