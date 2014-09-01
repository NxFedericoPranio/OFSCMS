using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;

namespace OFSCore.Util
{
    public class OFSSession
    {
        public System.Web.SessionState.HttpSessionState SessionState { get; private set; }

        public OFSSession(HttpSessionState SessionState)
        {
            if (SessionState == null)
                throw new ApplicationException("Session not valorized");
            this.SessionState = SessionState;
        }

        public object GetValue(string key, bool delete = false) {

            object res = SessionState[key];

            if (delete)
            {
                SessionState.Remove(key);
            }

            return res;
        }

        public void SetValueValue(string key, object value)
        {

             SessionState.Add(key, value);

        }
    }
}
