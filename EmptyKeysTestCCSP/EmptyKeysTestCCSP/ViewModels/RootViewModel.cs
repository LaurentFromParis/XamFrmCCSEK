using EmptyKeys.UserInterface.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmptyKeysTestCCSP.ViewModels
{
    public class RootViewModel : ViewModelBase
    {
        private string textBoxText;

        /// <summary>
        /// Gets or sets the text box text.
        /// </summary>
        /// <value>
        /// The text box text.
        /// </value>
        public string TextBoxText
        {
            get { return textBoxText; }
            set { SetProperty(ref textBoxText, value); }
        }

        public RootViewModel()
        {
            TextBoxText = "Empty keys integration done !";
        }
    }
}
