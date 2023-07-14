using EntityLayer;
using System.Data.Linq.Mapping;
using System.Data.Entity;

namespace DataLayer
{
    /// <summary>
    /// Database context for the Inventory database.
    /// </summary>
    /// MappingSource: Клас містить приватне поле _mappingSource, яке представляє джерело мапування для моделі даних. 
    /// У даному випадку використовується AttributeMappingSource, який використовує атрибути для визначення мапування
    /// між класами сутностей і таблицями бази даних.Клас InventoryContext є основним засобом взаємодії з базою даних
    /// "Inventory" у контексті Entity Framework.Він надає доступ до таблиць бази даних і дозволяє виконувати операції, 
    /// такі як додавання, зміна, видалення та запити до бази даних.
    public class InventoryContext : DbContext
    {
        private static MappingSource _mappingSource = new AttributeMappingSource();

        public InventoryContext() : base() { }

        public InventoryContext(string connectionstring) :base(connectionstring) { }

        public InventoryContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PartnerEntity> Partners { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
        public DbSet<TransactionBodyEntity> TransactionBody { get; set; }
        public DbSet<TransactionHeadEntity> TransactionHeader { get; set; }
    }
}