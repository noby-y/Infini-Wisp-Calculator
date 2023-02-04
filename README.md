# Infini-wisp Calculator

## Table of Contents

* [**General Info**](#general-information)
* [**Features**](#features)
* [**How to use**](#how-to-use)
* [**TODO**](#todo)
* [**Contact**](#contact)

## General Information

This is a *brutefore* calculator of infini-wisps for Noita. 
It is recomended to have a decent CPU to reduce calculation time.

## Features
- Outputs all possible permutations of modifier set [^1]
- Supports a range of lifetime values as input to account 
for lifetime randomness [^2]

## How to use

1. Download `Release.zip`
2. Unpack and open the folder
3. Run `WispCalculator.exe` for console app
    - Run `WispCalculatorCSV.bat` for CSV output
## TODO
- [x] Use lifetime ranges
- [x] Output into a CSV file
- [ ] Selection through modifier bans
    - allow to ban certain modifiers to only output specific permutations
- [ ] Support for negative lifetime values
- [ ] Higher *valid for calculation* max lifetime 
    - current highest lifetime decrease -> 7,200

## Contact
Created by @Noby#3046 - you can find me in [official Noita discord](https://discord.gg/noita)


### [Back to the top](#infini-wisp-calculator) 

[^1]: Each modifier can either be included or excluded from the build. 
There are a total of 6 modifiers with different lifetime values 
(orbit and ping-pong are the same)
which adds up to 6 binary choices or `2^6 = 64` permutations 
(some permutations are impossible and therefore redundant and are only shown in a CSV).

[^2]: Some projectiles can spawn with a random lifetime from a certain range. 
See [this](https://noita.wiki.gg/wiki/Guide_To_Infinite_Lifetime_Spells#Table_of_spells) 
table to find the right lifetime range.
