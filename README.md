# Bojovník: Aréna (C# Console, 2021)

Konzolová "pavouk" aréna z roku 2021. Turnaj 2-16 bojovníků, náhodná i ruční konfigurace postav a barevné výpisy do konzole.  
Archivováno jako vzpomínka na začátky s C# 😊

## Demo
<img src="https://media.martinben.es/bojovnikarenademo.gif" alt="Demo gif" width="400">

## Funkce
- turnaj pro **2 / 4 / 8 / 16** bojovníků (volba na začátku)
- **Režimy:** manuální `m`, poloautomatický `p`, automatický `a`. Manuální režim ti umožní jména/staty vyplnit ručně, ostatní generují náhodně.  
- **Třídy postav:**
  - **Berserker** - šance na **dvojnásobný útok**
  - **Warrior (Bojovník)** - šance **zablokovat útok**
  - **Archer (Lukostřelec)** - šance **vyhnout se útoku**
  - **Mage (Mág)** - je **cool**
- **Zápis výsledků** do `bojovnik-arena.txt` na plochu + nabídka otevření v notepadu po dohrání

## Ovládání a průběh
- po spuštění zvolíš **počet bojovníků** a **režim**
- v manuálním režimu vybíráš typ postavy (`b` berserker, `m` mág, `w` warrior, `a` archer) a vyplňuješ **HP (50-100)**, **DMG (25-50)** a příslušnou **šanci (10-50)** 
- mezi koly potvrzuješ libovolnou klávesou (v auto režimu se kroky zrychlí/omezí)
- po turnaji se zeptá na otevření logu v Notepadu (`y`) a na novou hru (`y`)

## Jak spustit
- **Visual Studio 2019/2022** (nebo novější) -> otevři projekt a spusť
> Pozn.: Aplikace nastavuje konzoli na 100x50 znaků; otevření logu přes `notepad.exe` je čistě **Windows** záležitost

## Technologie
- C# / .NET 5 - konzolová aplikace

## Poznámky

- během turnaje se průběžně vypisují životy a zásahy každého duelu; vítěz turnaje je zapsán do logu s dnešním datem
- kód je **archivovaný** z roku 2021 (bez údržby, možná v budoucnu, znáš to)
