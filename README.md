# tss-coding-challenge

## Building, testing and starting the Applicataion


### Example:

``` 
docker build -t tss-coding-challenge .
docker run tss-coding-challenge "[25,30] [2,19] [14, 23] [4,8]"
```

## IntervalService
The [IntervalService.cs](./src/TSSCodingChallenge.IntervalMerge/IntervalService.cs) contains three methods:

* **ValidateAndParseIntervalsString:** Takes string as input and parses it into a list of tuples. If the input is not valid this method throws an exception 
* **IntervalService:** At start this method sorts the intervals by the first value. Then it's scans the list item by item and adds each item to a new List.
If the item has to be merged with the previous one, it merges both items into one and proceeds with the next item.ch
* **PrintIntervals:** Prints a list of intervals to stdout.



## Complexity

* **Sort:** ***O(n log n)*** The [.NET Framework](https://docs.microsoft.com/de-de/dotnet/api/system.collections.generic.list-1.sort?view=net-5.0) uses Quicksort for sorting lists
* **Merge:** ***O(n)***, since merging the intervals is just a linear inspection of the intervals list
* **Overall:** ***O(n log n)*** i'd estimate this is the best possible complexity possible.

## Storage complexity
* **Storage complexity :** ***O(n)***

## Perspective on resilience

You can improve the stability of the application for large inputs by dividing and conquering!
For example split a extremly long output into *n* parts, and put them into 10 parallel running instances of this program. Heuristically you could tell every part gets smaller after, so you can now merge the results and run them through the program again. 