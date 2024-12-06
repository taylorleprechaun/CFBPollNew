# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS)

### Recent changes

* 9/2/2024: Merged in start of some UI changes which I haven't worked on in idk like 8 months. Also made some fixes to typical early season issues due to incomplete/missing data.
* 9/3/2024: Slight adjustments to Predictions algorithm. Small code adjustments to improve the experience of running everything.
* 10/13/2024: Added strength of schedule to the info I post here

### Rankings (Updated 12/1/2024)

**Week 15 Rankings**

Rank | Team | Rating | Record | SoS | SoS Rank
---|---|---|---|---|---
1 | Oregon | 1.0000 | 12-0 | 0.5437 | 57
2 | Texas | 0.9550 | 11-1 | 0.5421 | 60
3 | SMU | 0.9404 | 11-1 | 0.5301 | 70
4 | Notre Dame | 0.9326 | 11-1 | 0.5344 | 66
5 | Ohio State | 0.9287 | 10-2 | 0.5696 | 32
6 | Penn State | 0.9204 | 11-1 | 0.5001 | 102
7 | Georgia | 0.9204 | 10-2 | 0.5687 | 34
8 | Indiana | 0.9170 | 11-1 | 0.4882 | 115
9 | Boise State | 0.9101 | 11-1 | 0.5151 | 86
10 | Alabama | 0.9021 | 9-3 | 0.5978 | 12
11 | Miami FL | 0.8982 | 10-2 | 0.5318 | 69
12 | Iowa State | 0.8964 | 10-2 | 0.5345 | 65
13 | Brigham Young | 0.8849 | 10-2 | 0.5194 | 83
14 | South Carolina | 0.8839 | 9-3 | 0.5809 | 24
15 | Syracuse | 0.8746 | 9-3 | 0.5760 | 28
16 | Tennessee | 0.8704 | 10-2 | 0.4965 | 105
17 | Arizona State | 0.8647 | 10-2 | 0.4937 | 109
18 | Mississippi | 0.8575 | 9-3 | 0.5357 | 64
19 | Louisville | 0.8519 | 8-4 | 0.5979 | 11
20 | UNLV | 0.8509 | 10-2 | 0.4946 | 107
21 | Clemson | 0.8501 | 9-3 | 0.5319 | 68
22 | Missouri | 0.8501 | 9-3 | 0.5389 | 62
23 | Illinois | 0.8486 | 9-3 | 0.5385 | 63
24 | Army | 0.8449 | 10-1 | 0.4554 | 128
25 | Duke | 0.8377 | 9-3 | 0.5242 | 79

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/2024-Week%2015.md)

#### Observations and Notes (Updated 12/1/2024)

* In the past before the conference championships I've done a bunch of scenarios to see who makes the playoff based on CCG results and I don't plan to do that this year. It's a little less interesting when there are 12 teams in play vs 4. Maybe if I get bored during the week I'll mess with it but don't expect anything.

#### Predictions (Updated 12/5/2024)

Week 15 Predictions: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2015.md)

Week 14 Results: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2014.md)

Results:
* Winner: 48 - 19 (71.6%)
* ATS: 35 - 32 (52.2%)
* O/U: 29 - 38 (43.3%)

Season Results:
* Winner: 474 - 218 (68.5%)
* ATS: 339 - 363 (48.3%)
* O/U: 346 - 356 (49.3%)

2023 Season Results:
* Winner: 507 - 232 (68.6%)
* ATS: 365 - 374 (49.4%)
* O/U: 366 - 373 (49.5%)

2022 Season Results:
* Winner: 485 - 240 (66.9%)
* ATS: 341 - 383 (47.1%)
* O/U: 372 - 352 (51.4%)

### TODO List (Updated 12/5/2023)

1. Tweak/improve/adjust prediction algorithm to a point where I'm happy with it. I found a [site](https://www.thepredictiontracker.com/ncaaresults.php) posted on r/CFB with the results of a bunch of predictive algorithms so I'll definitely use this as some benchmarks when updating my algorithm. As of writing this my outright picks are on the low end, my ATS picks are middle of the pack, and my RMSE is really really bad lol.

2. More print-outs: conference average rating, conference top to bottom rating+ranking, conference ranking, division ranking, etc.

3. Add a UI.  This is currently a command line project.  I want to add a UI with dropdowns for the season and sections for outputs and stuff.
	
4. Add improvements for early season ratings (recruiting info, returning production stats, etc. (not sure where to get this data though))

5. ????

### Misc.

**The Best and Worst of all Time!**

My poll, as of this update, has been run across every season from 2000 through 2022 (that's because sports-reference only goes back to the year 2000) (using my new rating formula, meaning the ratings from all previous posts aren't totally accurate to what you'll see here, but the formula is way better now, trust me)

Something I noticed across these seasons is that the best teams had a rating above 40 and the worst teams were below 16, so I made a list of them [here]( https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/Resources/BOAT%20and%20WOAT.xlsx).

I decided to split up the rankings between pre-CFP and CFP eras.  This was because the teams in the CFP would get little bumps from playing an extra game against an elite-level team.
I'm probably going to have to split the CFP era into 4 and 12 team sections but that's a problem for future me

*New additions for the 2023 season!*

* This year Michigan clocks in with a 42.244 in my poll, placing them at #3 in the Playoff Era
* This year Kent State clocks in with a 15.812 in my poll, placing them at 11th worst in the Playoff Era

**The top 5 Best of all Time (pre-CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2001 | Miami FL | 42.309 | 12-0
2 | 2009 | Alabama | 41.756 | 14-0
3 | 2010 | Auburn | 41.464 | 14-0
4 | 2005 | Texas | 41.291 | 13-0
5 | 2000 | Oklahoma | 41.246 | 13-0

**The top 5 Best of all Time (CFP era)**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2018 | Clemson | 42.445 | 15-0
2 | 2019 | LSU | 42.374 | 15-0
3 | 2022 | Michigan | 42.244 | 15-0
4 | 2022 | Georgia | 42.124 | 15-0
5 | 2015 | Alabama | 41.615 | 14-1

**The bottom 5 Worst of all Time**

Rank | Year | Team | Rating | Record
---|---|---|---|---
1 | 2019 | Akron | 13.370 | 0-12
2 | 2009 | EMU | 13.809 | 0-12
3 | 2004 | UCF | 13.954 | 0-11
4 | 2013 | Miami OH | 13.973 | 0-12
5 | 2006 | FIU | 14.394 | 0-12
