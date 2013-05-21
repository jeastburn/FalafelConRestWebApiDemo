using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RestWebApi.Models
{
    using System.Xml.Serialization;

    using Newtonsoft.Json;

    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
        public sealed class ProductMetadata
        {
            private ProductMetadata()
            {
            }

            [IgnoreDataMember]
            public byte[] ThumbNailPhoto { get; set; }
        }
    }
}