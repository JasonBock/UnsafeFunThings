| Method                                | Mean       | Error     | StdDev    | Ratio | RatioSD | Gen0   | Allocated | Alloc Ratio |
|-------------------------------------- |-----------:|----------:|----------:|------:|--------:|-------:|----------:|------------:|
| SetFieldsAndComputeViaReflection      | 51.1191 ns | 0.9733 ns | 0.9104 ns | 1.000 |    0.02 | 0.0069 |     120 B |        1.00 |
| SetFieldsAndComputeViaUnsafeAccessors |  0.4266 ns | 0.0125 ns | 0.0117 ns | 0.008 |    0.00 |      - |         - |        0.00 |