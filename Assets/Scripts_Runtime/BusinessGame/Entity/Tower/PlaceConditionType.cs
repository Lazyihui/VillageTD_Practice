using System;

namespace TD {

    // 放置类型
    [Flags]
    public enum PlaceConditionType : int {
        None,
        Land = 1 << 0, // 地面, 0000 0001
        Pool = 1 << 1, // 水池, 0000 0010
        Tree = 1 << 2, // 树, 0000 0100
        Flower = 1 << 3, // 花, 0000 1000
    }
}