﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 16.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Microsoft.StreamProcessing
{
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "16.0.0.0")]
    internal partial class GroupedAfaEventListTemplate : AfaTemplate
    {
        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            this.Write(@"// *********************************************************************
// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License
// *********************************************************************
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;
using Microsoft.StreamProcessing;
using Microsoft.StreamProcessing.Internal;
using Microsoft.StreamProcessing.Internal.Collections;

// CompiledGroupedAfaPipe_EventList
// TKey: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write("\r\n// TPayload: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TPayload));
            this.Write("\r\n// TRegister: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write("\r\n// TAccumulator: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TAccumulator));
            this.Write("\r\n\r\n[DataContract]\r\ninternal sealed class ");
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            this.Write(" : CompiledAfaPipeBase<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TPayload));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TAccumulator));
            this.Write(">\r\n{\r\n    ");
            this.Write(this.ToStringHelper.ToStringWithCulture(staticCtor));
            this.Write("\r\n\r\n    [DataMember]\r\n    protected FastMap<GroupedActiveState<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write(">> activeStates;\r\n\r\n    protected FastMap<GroupedActiveState<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write(">>.FindTraverser activeFindTraverser;\r\n\r\n    [DataMember]\r\n    protected FastMap<" +
                    "SavedEventList<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TPayload));
            this.Write(">> currentTimestampEventList;\r\n\r\n    protected FastMap<SavedEventList<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TPayload));
            this.Write(">>.FindTraverser eventListTraverser;\r\n    protected FastMap<SavedEventList<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TPayload));
            this.Write(">>.VisibleTraverser allEventListTraverser;\r\n\r\n    [DataMember]\r\n    protected lon" +
                    "g lastSyncTime;\r\n\r\n    private long[] dest_vsync;\r\n    private long[] dest_vothe" +
                    "r;\r\n    private ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write("[] destkey;\r\n    private int[] dest_hash;\r\n    private ");
            this.Write(this.ToStringHelper.ToStringWithCulture(resultBatchTypeName));
            this.Write(" resultBatch;\r\n\r\n    public ");
            this.Write(this.ToStringHelper.ToStringWithCulture(className));
            this.Write("(\r\n        IStreamable<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write("> stream,\r\n        IStreamObserver<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write("> observer,\r\n        object afa,\r\n        long MaxDuration)\r\n        : base(strea" +
                    "m, observer, afa, MaxDuration)\r\n    {\r\n        activeStates = new FastMap<Groupe" +
                    "dActiveState<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write(">>();\r\n        activeFindTraverser = new FastMap<GroupedActiveState<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write(">>.FindTraverser(activeStates);\r\n\r\n        currentTimestampEventList = new FastMa" +
                    "p<SavedEventList<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TPayload));
            this.Write(">>();\r\n        eventListTraverser = new FastMap<SavedEventList<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TPayload));
            this.Write(">>.FindTraverser(currentTimestampEventList);\r\n        allEventListTraverser = new" +
                    " FastMap<SavedEventList<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TPayload));
            this.Write(@">>.VisibleTraverser(currentTimestampEventList);
        lastSyncTime = -1;
    }

    public override int CurrentlyBufferedInputCount => activeStates.Count;

    private void ProcessCurrentTimestamp()
    {
        int el_index, el_hash;
        long synctime = lastSyncTime;

        allEventListTraverser.currIndex = 0;

        while (allEventListTraverser.Next(out el_index, out el_hash))
        {
            var currentList = currentTimestampEventList.Values[el_index];

            /* (1) Process currently active states */
            bool ended = true;
            if (activeFindTraverser.Find(el_hash))
            {
                int index, orig_index;
                
                // Track which active states need to be inserted after the current traversal
                var newActiveStates = new List<GroupedActiveState<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write(">>();\r\n                while (activeFindTraverser.Next(out index))\r\n             " +
                    "   {\r\n                    orig_index = index;\r\n\r\n                    var state =" +
                    " activeStates.Values[index];\r\n                    if (!(");
            this.Write(this.ToStringHelper.ToStringWithCulture(keyEqualityComparer("state.key", "currentList.key")));
            this.Write(")) continue;\r\n\r\n                    if (state.PatternStartTimestamp + MaxDuration" +
                    " > synctime)\r\n                    {\r\n                        switch (state.state" +
                    ") {\r\n                            ");
 foreach (var sourceNodeInfo in this.currentlyActiveInfo) { 
            this.Write("\r\n                            case ");
            this.Write(this.ToStringHelper.ToStringWithCulture(sourceNodeInfo.Item1));
            this.Write(" :\r\n                                ");
 foreach (var edge in sourceNodeInfo.Item2) { 
            this.Write("\r\n                                if (");
            this.Write(this.ToStringHelper.ToStringWithCulture(edge.Fence("synctime", "currentList.payloads", "state.register")));
            this.Write(") {\r\n                                    // assign new register value\r\n          " +
                    "                          ");
 UpdateRegisterValue(edge, "state.register", "synctime", "currentList.payloads", "state.register"); 
            this.Write("                                    // target nodes\r\n                            " +
                    "        ");
 foreach (var ns in edge.EpsilonReachableNodes) { 
            this.Write("\r\n                                    // target state: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ns));
            this.Write(" (");
            this.Write(this.ToStringHelper.ToStringWithCulture(isFinal[ns] ? "final" : "not final"));
            this.Write(")\r\n                                    ");
 IfFinalStateProduceOutput(36, ns, string.Empty, "synctime", "state.PatternStartTimestamp", "currentList.key", "el_hash"); 
            this.Write("                                    ");
 if (hasOutgoingArcs[ns]) { 
            this.Write(@"
                                    // target node has outgoing edges
                                    // Since we will eventually remove this state/index from activeStates, attempt to reuse this index for the outgoing state instead of deleting/re-adding
                                    // If index is already -1, this means we've already reused the state and must allocate/insert a new index for the outgoing state.
                                    if (index != -1)
                                    {
                                        activeStates.Values[index].key = currentList.key;
                                        activeStates.Values[index].state = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ns));
            this.Write(@";
                                        activeStates.Values[index].register = newReg;
                                        activeStates.Values[index].PatternStartTimestamp = state.PatternStartTimestamp;

                                        index = -1;
                                    }
                                    else
                                    {
                                        // Do not attempt to insert directly into activeStates, as that could corrupt the traversal state.
                                        newActiveStates.Add(new GroupedActiveState<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TRegister));
            this.Write(">\r\n                                        {\r\n                                   " +
                    "         key = currentList.key,\r\n                                            sta" +
                    "te = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ns));
            this.Write(@",
                                            register = newReg,
                                            PatternStartTimestamp = state.PatternStartTimestamp,
                                        });
                                    }

                                    ended = false;
                                    ");
 } else { 
            this.Write("\r\n                                    // target node does not have any outgoing e" +
                    "dges\r\n                                    ");
 } 
            this.Write("                                    ");
 } 
            this.Write("\r\n                                }\r\n                                ");
 } 
            this.Write("\r\n                                break;\r\n\r\n                            ");
 } 
            this.Write(@"
                        }
                    }
                    if (index == orig_index) activeFindTraverser.Remove();
                    if (IsDeterministic) break; // We are guaranteed to have only one active state
                }

                // Now that we are done traversing the current active states, add any new ones.
                foreach (var newActiveState in newActiveStates)
                {
                    this.activeStates.Insert(el_hash, newActiveState);
                }
            }

            /* (2) Start new activations from the start state(s) */
            ");
 if (!this.AllowOverlappingInstances) { 
            this.Write("\r\n            if (!ended) continue;\r\n            ");
 } 
            this.Write("\r\n            ");
 foreach (var sourceNodeInfo in this.newActivationInfo) { 
            this.Write("\r\n                // start node: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(sourceNodeInfo.Item1));
            this.Write("\r\n                ");
 foreach (var edge in sourceNodeInfo.Item2) { 
            this.Write("\r\n                if (");
            this.Write(this.ToStringHelper.ToStringWithCulture(edge.Fence("synctime", "currentList.payloads", "defaultRegister")));
            this.Write(") {\r\n                    // initialize register\r\n                    ");
 UpdateRegisterValue(edge, "defaultRegister", "synctime", "currentList.payloads", "defaultRegister"); 
            this.Write("                    // target nodes\r\n                    ");
 foreach (var ns in edge.EpsilonReachableNodes) { 
            this.Write("\r\n                    // target state: ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ns));
            this.Write(" (");
            this.Write(this.ToStringHelper.ToStringWithCulture(isFinal[ns] ? "final" : "not final"));
            this.Write(")\r\n                    ");
 IfFinalStateProduceOutput(52, ns, string.Empty, "synctime", "synctime", "currentList.key", "el_hash"); 
            this.Write("                    ");
 if (hasOutgoingArcs[ns]) { 
            this.Write(@"
                    // target node has outgoing edges
                    {
                        var index = activeStates.Insert(el_hash);
                        activeStates.Values[index].key = currentList.key;
                        activeStates.Values[index].state = ");
            this.Write(this.ToStringHelper.ToStringWithCulture(ns));
            this.Write(";\r\n                        activeStates.Values[index].register = newReg;\r\n       " +
                    "                 activeStates.Values[index].PatternStartTimestamp = synctime;\r\n " +
                    "                   }\r\n                    ");
 } else { 
            this.Write("\r\n                    // target node does not have any outgoing edges\r\n          " +
                    "          ");
 } 
            this.Write("                    ");
 } 
            this.Write("\r\n                }\r\n                ");
 } 
            this.Write("            ");
 } 
            this.Write("        }\r\n\r\n        currentTimestampEventList.Clear();\r\n    }\r\n\r\n    public over" +
                    "ride unsafe void OnNext(StreamMessage<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TPayload));
            this.Write("> batch)\r\n    {\r\n        this.dest_vsync = this.batch.vsync.col;\r\n        this.de" +
                    "st_vother = this.batch.vother.col;\r\n        this.destkey = this.batch.key.col;\r\n" +
                    "        this.dest_hash = this.batch.hash.col;\r\n\r\n        var count = batch.Count" +
                    ";\r\n\r\n        var srckey = batch.key.col;\r\n\r\n        fixed (long* src_bv = batch." +
                    "bitvector.col, src_vsync = batch.vsync.col, src_vother = batch.vother.col)\r\n    " +
                    "    {\r\n            fixed (int* src_hash = batch.hash.col)\r\n            {\r\n      " +
                    "          for (int i = 0; i < count; i++)\r\n                {\r\n                  " +
                    "  if ((src_bv[i >> 6] & (1L << (i & 0x3f))) == 0 || src_vother[i] < 0)\r\n        " +
                    "            {\r\n                        long synctime = src_vsync[i];\r\n\r\n        " +
                    "                if (synctime > lastSyncTime) // move time forward\r\n             " +
                    "           {\r\n                            ProcessCurrentTimestamp();\r\n          " +
                    "                  lastSyncTime = synctime;\r\n                        }\r\n\r\n       " +
                    "                 if (src_vother[i] < 0)\r\n                        {\r\n            " +
                    "                OnPunctuation(synctime);\r\n                            this.dest_" +
                    "vsync = this.batch.vsync.col;\r\n                            this.dest_vother = th" +
                    "is.batch.vother.col;\r\n                            this.destkey = this.batch.key." +
                    "col;\r\n                            this.dest_hash = this.batch.hash.col;\r\n       " +
                    "                     continue;\r\n                        }\r\n\r\n                   " +
                    "     bool done = false;\r\n                        int index, hash;\r\n\r\n           " +
                    "             if (eventListTraverser.Find(src_hash[i]))\r\n                        " +
                    "{\r\n                            while (eventListTraverser.Next(out index))\r\n     " +
                    "                       {\r\n                                var state = currentTim" +
                    "estampEventList.Values[index];\r\n\r\n                                if (");
            this.Write(this.ToStringHelper.ToStringWithCulture(keyEqualityComparer("state.key", "srckey[i]")));
            this.Write(@")
                                {
                                    state.payloads.Add(batch[i]);
                                    done = true;
                                    break;
                                }
                            }
                        }

                        if (!done)
                        {
                            index = currentTimestampEventList.Insert(src_hash[i]);
                            var list = new List<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TPayload));
            this.Write(">(10);\r\n                            list.Add(batch[i]);\r\n                        " +
                    "    currentTimestampEventList.Values[index] = new SavedEventList<");
            this.Write(this.ToStringHelper.ToStringWithCulture(TKey));
            this.Write(", ");
            this.Write(this.ToStringHelper.ToStringWithCulture(TPayload));
            this.Write("> { key = srckey[i], payloads = list };\r\n                        }\r\n             " +
                    "       }\r\n                }\r\n            }\r\n        }\r\n        batch.Free();\r\n  " +
                    "  }\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
}
