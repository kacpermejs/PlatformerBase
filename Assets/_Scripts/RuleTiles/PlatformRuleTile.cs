using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class PlatformRuleTile : RuleTile<PlatformRuleTile.Neighbor> {

    public class Neighbor : RuleTile.TilingRule.Neighbor {
    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        return base.RuleMatch(neighbor, tile);
    }
}