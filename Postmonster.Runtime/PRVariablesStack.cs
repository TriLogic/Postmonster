using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Runtime
{
    public class PMVariablesStack
    {
        private PRVariables _globals;
        private List<PRVariables> _stack;

        #region Constructors and Destructors
        public PMVariablesStack()
        {
            _stack = new();
            _globals = new();
            push(_globals);
        }

        public PMVariablesStack(PRVariables items)
        {
            _stack = new();
            _globals = items == null ? new() : items;
            push(_globals);
        }
        #endregion

        #region Convenience Properties
        public PRVariables globals { get => _globals; }
        public PRVariables locals { get => _stack[^1]; }
        public int level => _stack.Count;
        #endregion

        #region Stack Operations
        public PRVariables push() => push(new PRVariables());

        public PRVariables push(PRVariables vars)
        {
            var item = vars == null ? new() : vars;
            _stack.Add(item);
            return item;
        }
        public PRVariables peek() => _stack[^1];

        public PRVariables? pop()
        {
            if (_stack.Count == 1)
                return null;

            var item = _stack[^1];
            _stack.RemoveAt(_stack.Count - 1);

            return item;
        }
        #endregion

        #region set, get, has, clear - (Globals Scope)
        public bool hasGlobal(string key) => globals.has(key);
        public void unsetGlobal(string key) => globals.unset(key);
        public string? getGlobal(string key) => globals.get(key);
        public void setGlobal(string key, string? value) => globals.set(key, value);
        public void clearGlobals() => _globals.clear();
        #endregion

        #region set, get, has, clear - (Full Scope)
        public void clear()
        {
            while (_stack.Count > 1)
            {
                var item = pop();
                item.clear();
            }

            _globals.clear();
        }

        public bool has(string key) => locate(key) != null;

        public void unset(string key)
        {
            var items = locate(key);
            if (items != null)
                items.unset(key);
        }

        public string? get(string key)
        {
            var items = locate(key);
            return items != null ? items.get(key) : null;
        }

        public void set(string key, string? value)
        {
            var items = locate(key);
            if (items != null)
                items.set(key, value);
        }

        public PRVariables? locate(string key)
        {
            for (int i = _stack.Count - 1; i >= 0; i--)
            {
                if (_stack[i].has(key))
                    return _stack[i];
            }

            return null;
        }

        internal string? this[string key]
        {
            get => get(key);
            set => set(key, value);
        }
        #endregion

        #region set, get, has, clear - (Locals Scope)
        public bool hasLocal(string key) => locals.has(key);
        public void unsetLocal(string key) => locals.unset(key);
        public string? getLocal(string key) => locals.get(key);
        public void setlocal(string key, string? value) => locals.set(key, value);
        public void clearLocals() => locals.clear();
        #endregion

    }
}
