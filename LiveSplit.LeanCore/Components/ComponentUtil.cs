using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace LiveSplit.LeanCore.Components
{
    using OffsetT = Int32;

    public class DeepPointer
    {
        public enum DerefType { Auto, Bit32, Bit64 }

        private IntPtr _absoluteBase;
        private bool _usingAbsoluteBase;
        private DerefType _derefType;

        private OffsetT _base;
        private List<OffsetT> _offsets;
        private string _module;

        public DeepPointer(IntPtr absoluteBase, params OffsetT[] offsets)
            : this(absoluteBase, DerefType.Auto, offsets) { }

        public DeepPointer(IntPtr absoluteBase, DerefType derefType, params OffsetT[] offsets)
        {
            _absoluteBase = absoluteBase;
            _usingAbsoluteBase = true;
            _derefType = derefType;

            InitializeOffsets(offsets);
        }

        public DeepPointer(string module, OffsetT base_, params OffsetT[] offsets)
            : this(module, base_, DerefType.Auto, offsets) { }

        public DeepPointer(string module, OffsetT base_, DerefType derefType, params OffsetT[] offsets)
            : this(base_, derefType, offsets)
        {
            _module = module.ToLower();
        }

        public DeepPointer(OffsetT base_, params OffsetT[] offsets)
            : this(base_, DerefType.Auto, offsets) { }

        public DeepPointer(OffsetT base_, DerefType derefType, params OffsetT[] offsets)
        {
            _base = base_;
            _derefType = derefType;
            InitializeOffsets(offsets);
        }

        private void InitializeOffsets(params OffsetT[] offsets)
        {
            _offsets = new List<OffsetT>();
            _offsets.Add(0); // deref base first
            _offsets.AddRange(offsets);
        }
    }
}
