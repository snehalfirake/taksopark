using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taksopark.WebForms.Classes
{
    public class GridViewEventArgs : EventArgs
    {
        #region Private Members

        private string _userId;

        #endregion Private Members

        #region Properties

        public string UserId
        {
            get
            {
                return this._userId;
            }
            set
            {
                this._userId = value;
            }
        }

        #endregion Properties

        #region Constructors

        public GridViewEventArgs(string userId)
        {
            this._userId = userId;
        }

        #endregion Constructors
    }
}