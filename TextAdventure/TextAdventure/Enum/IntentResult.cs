using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextAdventure.Enum;

/// <summary>
/// Result of the intent discovery service
/// </summary>
public enum IntentResult
{
    /// <summary>
    /// User response matched up with an available choice
    /// </summary>
    MatchedChoice = 1,

    /// <summary>
    /// User response did not match up with an available choice
    /// </summary>
    UnclearChoice = 2
}
