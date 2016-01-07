# cfg_algorithm

Program that allows you to extract raw data from the CFR and convert it into an excel file. Extraction can be done by specifying an interval period. Each session will then be divided in bins equal to this interval, and the percentage of freezing in each bin will be calculated. Alternatively a list of specific time intervals can be specified. The algorithm will then look at the percentage freezing in each of the specified intervals.

The following parameters can be adjusted:
* Activity Threshold    : maximum activity value before a sample can be considered to be part of a freezing period
* Time To Threshold(TTR): how long animal activity has to be below threshold activity before a period is counted as a freezing period

