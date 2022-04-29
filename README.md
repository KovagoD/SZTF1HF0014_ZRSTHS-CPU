# SZTF1HF0014_ZRSTHS-CPU
Az egyszálú processzorok működésük során legfeljebb egy feladatot tudnak feldolgozni, de hogy
pontosan melyiket, az a következőképpen alakul:
- ha a CPU idle állapotban van és nincsenek feldolgozható feladatok, akkor idle állpotban marad,
- ha a CPU idle állapotban van és vannak feldolgozásra váró feladatok, akkor a CPU a
legrövidebb feldolgozási idővel rendelkezőt választja (ha több ilyen feladat is volna, akkor a
legkisebb indexű feladatot választja),
- egy feladat elindítása után a CPU megszakítás nélkül dolgozza fel a teljes feladatot,
- a CPU egy feladat befejezését követően ugyanabban az időpillanatban elindíthatja egy másik
feladat feldolgozását.

A CPU által feldolgozandó feladatokról (T) tudjuk, hogy melyik időpillanattól lehetséges a
feldolgozásuk (Te) és, hogy mennyi ideig tart azt feldolgozni (Tp).
A cél annak meghatározása, hogy a CPU milyen sorrendben dolgozza fel az N feladatot.

Bemenet (Console)
- első sor, a feldolgozandó feladatok száma (N)
- a következő N sor, az i. feladathoz tartozó rendelkezésre állási és feldolgozási idő páros
vesszővel elválasztva (Te, Tp)

Kimenet (Console)
- a T feladatok indexei a feldolgozási sorrendjük szerint rendezve

Megkötés(ek)
- 1 ≤ N ≤ 105
- 1 ≤ Te, Tp ≤ 109
