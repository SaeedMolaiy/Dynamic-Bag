using System.Collections.Generic;
using System;
using System.Dynamic;

namespace DynamicBag.Model
{
    public class DynamicBag : DynamicObject
    {
        private readonly Dictionary<string, dynamic> _members;

        public DynamicBag()
        {
            _members = new Dictionary<string, dynamic>(StringComparer.InvariantCultureIgnoreCase);
        }

        // If you try to get a value of a member
        // not defined in the class, this method is called.
        public override bool TryGetMember(GetMemberBinder binder, out dynamic member)
        {
            // Converting the member name to lowercase
            // so that member names become case-insensitive.
            var binderName = binder.Name.ToLower();

            // If the member name is found in a dictionary,
            // set the out member parameter to the member value and return true.
            // Otherwise, return false.
            member = _members[binderName];

            return member != null;
        }

        public override bool TrySetMember(SetMemberBinder binder, dynamic value)
        {
            // Converting the member name to lowercase
            // so that member names become case-insensitive.
            var binderName = binder.Name.ToLower();

            if (value == null)
            {
                if (_members.ContainsKey(binderName))
                {
                    _members.Remove(binderName);
                }
            }
            else
            {
                _members[binderName] = value;
            }
            // You can always add a value to a dictionary,
            // so this method always returns true.
            return true;
        }

    }
}
