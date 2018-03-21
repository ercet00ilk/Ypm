using System;
using System.ComponentModel.DataAnnotations;

namespace YPM.SuretVarlik.Mulk.Nitelik.Kisi
{
    /// <summary>
    /// Validasyon Attribütü.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class KesinDogruDonerAttribute
        : ValidationAttribute
    {
        /// <summary>
        /// Sonucun kesinlike doğru dönmesi için kullanılır.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            return value != null && value is bool && (bool)value;
        }
    }
}