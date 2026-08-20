using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Intensive.Services.CTKAPIWrapper
{
    /// <summary>
    /// A small handful of queries(or methods) will return a set of <i>tuples</i>, instead
    /// of a set of key/value pairs.  In.Net-speak, a tuple is like an ArrayList or a generic List&lt;object&gt;
    /// 
    /// Similar to the <see cref="CTKResultDictionary"/>, each item in the CTKResultTuple list 
    /// represent an entity returned and the "sub-List" represents the tuples returned by the query/action.
    /// </summary>
    public class CTKResultTuple : List<List<object>> { }
}
