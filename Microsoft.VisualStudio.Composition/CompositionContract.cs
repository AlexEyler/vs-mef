﻿namespace Microsoft.VisualStudio.Composition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Validation;

    public class CompositionContract : IEquatable<CompositionContract>
    {
        public CompositionContract(string contractName, Type type)
        {
            Requires.NotNull(type, "type");

            this.ContractName = contractName;
            this.Type = type;
        }

        public string ContractName { get; private set; }

        public Type Type { get; private set; }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as CompositionContract);
        }

        public bool Equals(CompositionContract other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Type == other.Type
                && StringComparer.Ordinal.Equals(this.ContractName, other.ContractName);
        }

        public override int GetHashCode()
        {
            return this.Type.GetHashCode() + StringComparer.Ordinal.GetHashCode(this.ContractName);
        }
    }
}