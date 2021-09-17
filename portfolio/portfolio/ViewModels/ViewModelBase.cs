using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace portfolio.ViewModels
{
    //In order to be able to bind the markup and model data two-way
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string
propertyName=null)
        {
            PropertyChanged?.Invoke(this, new
           PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Method for changing property (event PropertyChanged)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prop">property for changing</param>
        /// <param name="value">new value</param>
        /// <param name="propName">property name</param>
        /// <returns></returns>
        protected bool Set<T>(ref T prop, T value, [CallerMemberName]
string propName=null)
        {
            if (Equals(prop, value)) return false;
            prop = value;
            OnPropertyChanged(propName);
            return true;
        }
    }
}
