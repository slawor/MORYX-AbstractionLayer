﻿using System.Linq;
using System.Threading.Tasks;
using Marvin.AbstractionLayer.UI;
using Marvin.Controls;

namespace Marvin.Resources.UI.Interaction
{
    [ResourceDetailsRegistration(DetailsConstants.DefaultType)]
    internal class DefaultDetailsViewModel : ResourceDetailsViewModelBase
    {
        private EntryViewModel _configViewModel;

        public EntryViewModel ConfigViewModel
        {
            get { return _configViewModel; }
            set
            {
                _configViewModel = value;
                NotifyOfPropertyChange();
            }
        }

        ///
        protected override Task OnConfigLoaded()
        {
            ConfigViewModel = new EntryViewModel(ConfigEntries);

            return base.OnConfigLoaded();
        }

        public override void BeginEdit()
        {
            ConfigViewModel = new EntryViewModel(ConfigEntries.Clone(true));

            base.BeginEdit();
        }

        public override void EndEdit()
        {
            ConfigEntries = ConfigViewModel.Entry;

            base.EndEdit();
        }

        public override void CancelEdit()
        {
            ConfigViewModel = new EntryViewModel(ConfigEntries);

            base.CancelEdit();
        }
    }
}