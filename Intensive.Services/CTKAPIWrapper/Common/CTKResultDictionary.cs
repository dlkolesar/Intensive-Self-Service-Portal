using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Intensive.Services.CTKAPIWrapper.Exceptions;

namespace Intensive.Services.CTKAPIWrapper
{
    /// <summary>
    /// The <b>CTKResultDictionary</b> object is the standard result returned by most queries.
    /// Each item in the list represents a single entity returned by the query; Each entity is 
    /// represented as a Dictionary object of key/value pairs, where the keys correspond to strings 
    /// in the the <b>Attributes</b> property of the <see cref="CTKQuery"/> object.
    /// 
    /// </summary>
    /// <remarks>
    /// NOTE: At this time the Dictionary object is not recursive;  If the value of a key is another dictionary,
    /// the returned value will be the json string representation of that dictionary.  The calling app will need 
    /// to further parse the JSON string into sub-dictionaries. 
    /// 
    /// </remarks>
    public class CTKResultDictionary : List<Dictionary<string,object>>{}


    
}
