# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS)

### Recent changes

* 1/21/2025: Final Poll 2024-25 + BOAT and WOAT Update
* 8/16/2025: Summer cleaning Part 1. Rearranged a lot of code and started moving towards a more modular and DB-driven design.
* 8/17/2025: Summer cleaning Part 2. More work towards DB-driven design and loading data into the system.
* 8/24/2025: Summer cleaning Part 3. Even more work towards DB-driven design and loading data into the system.

### Rankings (Updated 1/21/2025)

**Week 18 Rankings**

Rank | Team | Rating | Record | SoS | SoS Rank
---|---|---|---|---|---
1 | Oregon | 1.0000 | 13-1 | 0.5962 | 15
2 | Ohio State | 0.9959 | 14-2 | 0.6257 | 6
3 | Notre Dame | 0.9578 | 14-2 | 0.5999 | 13
4 | Texas | 0.9343 | 13-3 | 0.5948 | 18
5 | Penn State | 0.9259 | 13-3 | 0.5823 | 27
6 | Georgia | 0.9205 | 11-3 | 0.6033 | 11
7 | Indiana | 0.9117 | 11-2 | 0.5336 | 79
8 | Boise State | 0.8993 | 12-2 | 0.5460 | 67
9 | Brigham Young | 0.8972 | 11-2 | 0.5261 | 85
10 | Iowa State | 0.8839 | 11-3 | 0.5554 | 56
11 | SMU | 0.8831 | 11-3 | 0.5542 | 61
12 | Syracuse | 0.8770 | 10-3 | 0.5633 | 40
13 | Mississippi | 0.8764 | 10-3 | 0.5447 | 68
14 | Illinois | 0.8744 | 10-3 | 0.5582 | 49
15 | Arizona State | 0.8715 | 11-3 | 0.5349 | 78
16 | Miami FL | 0.8707 | 10-3 | 0.5440 | 70
17 | Alabama | 0.8670 | 9-4 | 0.5955 | 16
18 | Missouri | 0.8612 | 10-3 | 0.5380 | 76
19 | South Carolina | 0.8593 | 9-4 | 0.5902 | 20
20 | Tennessee | 0.8584 | 10-3 | 0.5287 | 82
21 | Louisville | 0.8526 | 9-4 | 0.5800 | 28
22 | Louisiana State | 0.8502 | 9-4 | 0.5849 | 23
23 | Clemson | 0.8499 | 10-4 | 0.5576 | 52
24 | Army | 0.8471 | 12-2 | 0.4975 | 116
25 | Navy | 0.8386 | 10-3 | 0.5536 | 63

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/2024-Week%2018%20NCG.md)

#### Observations and Notes (Updated 1/21/2025)

* And your National Champion is........... Oregon. Yeah idk it's kind of weird how they're still #1. From what I can tell looking at the code that rates the teams the main difference comes from the winning percentage component of the ranking.  13-1 with the #15 strength of schedule is perceived as better than 14-2 with the #6 strength of schedule. I don't *love* it but that's what we're going with. Maybe I'll adjust it a little for next season to reward teams that go further in the playoff. 

#### Predictions (Updated 1/21/2025)

National Championship Results: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2017%20NCG.md)

Retrospective:
I came into this season with a goal of >70% for Winner and >50% for both ATS and O/U. I had re-run the entirety of 2023 multiple times while testing my changes for 2024 and I hit those marks. But as the season went on I noticed my Winner and O/U predictions were not where I wanted them to be. Around week 8 (ish) I made some adjustments which improved the O/U predictions by a decent amount but the ATS predictions fell off the rest of the way through the season. I have ideas for how to adjust things so next year though I'll have more changes and improvements so I can hit that goal.

2024 Season Results:
* Winner: 510 - 238 (68.2%)
* ATS: 364 - 394 (48.0%)
* O/U: 374 - 384 (49.3%)

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
I'm probably going to have to split the CFP era into 4 and 12 team sections but that's a problem for future me. As of right now I'm not going to split into 4 vs 12 but maybe in the future I will

*New additions for the 2024 season!*

* No one cracked 40 points so no one is making it into the BOAT section for 2024. Oregon came closest at 39.962 and Ohio State was a little behind at 39.802
* Kent State repeats this year as worst team in FBS. They finished with a rating of 15.735, placing them at 9th worst in the Playoff Era

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
3 | 2023 | Michigan | 42.244 | 15-0
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
