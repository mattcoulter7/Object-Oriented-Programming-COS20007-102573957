using System.Collections.Generic;

namespace Swin_Adventure2
{
    class IdentifiableObject
    {
        //private field
        private List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents)
        {
           foreach(string id in idents)
            {
                AddIdentifier(id.ToLower());
            }
        }
        public List<string> Identifiers
        {
            get { return _identifiers; }
            set { _identifiers = value; }
        }

        public bool AreYou(string id)
        {
                return _identifiers.Contains(id.ToLower());
        }

        public string FirstId()
        {
            return _identifiers[0];
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }
    }
}
