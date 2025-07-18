using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class PlatformRuleTile : RuleTile<PlatformRuleTile.Neighbor> {
    public bool customField;

    public class Neighbor : RuleTile.TilingRule.Neighbor {
        public const int Null = 3;
        public const int NotNull = 4;
    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        return base.RuleMatch(neighbor, tile);
    }
}