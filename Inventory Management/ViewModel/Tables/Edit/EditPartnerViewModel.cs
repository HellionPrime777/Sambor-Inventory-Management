﻿using EntityLayer;
using Inventory_Management.Model;
using BusinessLayer;

namespace Inventory_Management.ViewModel
{
    public class EditPartnerViewModel : EditItemModel<PartnerEntity>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public EditPartnerViewModel(PartnerEntity item, bool newRecord, string itemName) : base(item, newRecord, itemName) { }

        protected override bool Save(object parameter)
        {
            log.Debug("Save " + ItemName);

            bool result = false;
            if (NewRecord)
            {
                result = ManagePartners.NewPartner(Item);
            }
            else
            {
                result = ManagePartners.ModifyPartner(Item);
            }
            return result;
        }
    }
}
