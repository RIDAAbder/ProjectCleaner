using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VCExtensibleStorageExtension;
using VCExtensibleStorageExtension.Attributes;

namespace ProjectCleaner
{
    [Schema("BA5F4DC2-9694-4E8F-AFF2-BDEA207BA010", "StoredParameters")]
    public class StorageForParameter:IRevitEntity
    {
        [Field]
        public List<string> Names { get; set; }
    }
}
