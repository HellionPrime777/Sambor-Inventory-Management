﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Inventory_Management.Model
{
    public class BindableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Клас BindableBase надає зручний спосіб реалізації механізму сповіщення про зміну властивостей для об'єктів, 
        /// які використовуються для прив'язки даних. Це полегшує роботу з прив'язкою даних та автоматично оновлює інтерфейс
        /// користувача при зміні значень властивостей.
        /// </summary>

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        protected virtual void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, val)) return;
            member = val;
            RaisePropertyChanged(propertyName);
        }
    }
}
