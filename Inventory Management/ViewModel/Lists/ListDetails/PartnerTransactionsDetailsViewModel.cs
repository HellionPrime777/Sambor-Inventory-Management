using EntityLayer;
using BusinessLayer;
using Inventory_Management.Model;

namespace Inventory_Management.ViewModel
{
    /// <summary>
    /// PartnerTransactionsDetailsViewModel надає функціональність для відображення деталей транзакцій партнера та обчислення загальної кількості транзакцій.
    /// </summary>
    class PartnerTransactionsDetailsViewModel : ListModel<TransactionHeadListEntity>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private PartnerTransactionsDetailsViewModel() { }
        public PartnerTransactionsDetailsViewModel(int partnerId)
            :this()
        {
            _partnerId = partnerId;
            RefreshList(null);
        }

        private int _partnerId;

        private decimal _totalTransactions;
        public decimal TotalTransactions
        {
            get { return _totalTransactions; }
            set { SetProperty(ref _totalTransactions, value); }
        }

        protected override void RefreshList(object parameter)
        {
            log.Debug("Refresh list: Partner transaction summary details");

            List = ManageTransactions.ListHead(_partnerId);
            TotalTransactions = 0;
            foreach (var record in List)
                TotalTransactions += record.ListVariable;
        }
    }
}
