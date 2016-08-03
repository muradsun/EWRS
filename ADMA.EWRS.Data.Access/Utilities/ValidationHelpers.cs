﻿using ADMA.EWRS.Data.Models.Validation;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADMA.EWRS.Data.Access.Utilities
{
    public class ValidationHelpers
    {
        public static List<ADMA.EWRS.Data.Models.Validation.ValidationError> TransformDbEntityValidationResult(IEnumerable<DbEntityValidationResult> dbEntityResults)
        {
            return dbEntityResults.SelectMany(
                   x => x.ValidationErrors.Select(y =>
                             new ValidationError(y.PropertyName, y.ErrorMessage, x.Entry.Entity.GetType().FullName)))
                   .ToList();
        }

        //    private static readonly Dictionary<int, string> _sqlErrorTextDict =
        //    new Dictionary<int, string>
        //{
        //    {547,
        //     "This operation failed because another data entry uses this entry."},
        //    {2601,
        //     "One of the properties is marked as Unique index and there is already an entry with that value."}
        //};

        //    /// <summary>
        //    /// This decodes the DbUpdateException. If there are any errors it can
        //    /// handle then it returns a list of errors. Otherwise it returns null
        //    /// which means rethrow the error as it has not been handled
        //    /// </summary>
        //    /// <param id="ex""></param>
        //    /// <returns>null if cannot handle errors, otherwise a list of errors</returns>
        //    IEnumerable<ValidationResult> TryDecodeDbUpdateException(DbUpdateException ex)
        //    {
        //        if (!(ex.InnerException is System.Data.Entity.Core.UpdateException) ||
        //            !(ex.InnerException.InnerException is System.Data.SqlClient.SqlException))
        //            return null;
        //        var sqlException =
        //            (System.Data.SqlClient.SqlException)ex.InnerException.InnerException;
        //        var result = new List<ValidationResult>();
        //        for (int i = 0; i < sqlException.Errors.Count; i++)
        //        {
        //            var errorNum = sqlException.Errors[i].Number;
        //            string errorText;
        //            if (_sqlErrorTextDict.TryGetValue(errorNum, out errorText))
        //                result.Add(new ValidationResult(errorText));
        //        }
        //        return result.Any() ? result : null;
        //    }



    }
}
