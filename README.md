# CFBPollNew

### About

Upgraded version of my original poll ([found here](https://github.com/taylorleprechaun/CFBPoll)).  Rewritten better with some upgrades

Poll pulls some data about teams and uses it to rank them.  Data used includes game-by-game results and offensive and defensive team stats.

In the poll, a team's "Score" is in relation to the #1 team.  The formula gives points to teams using the data it has.  Once all the teams are ranked it measures against the highest score given out.  So, if Clemson is #1 and they earned 123 points from the poll, then every team's points will be divided by 123 to get their final score.

Made for fun.  Part of the Massey Composite (Steinberg/TSS)

### Recent changes

* 9/2/2024: Merged in start of some UI changes which I haven't worked on in idk like 8 months. Also made some fixes to typical early season issues due to incomplete/missing data.
* 9/3/2024: Slight adjustments to Predictions algorithm. Small code adjustments to improve the experience of running everything.

### Rankings (Updated 9/15/2024)

**Week 4 Rankings**

Rank | Team | Score | Record
---|---|---|---
1 | Alabama | 1.0000 | 3-0
2 | Georgia | 0.9883 | 3-0
3 | Ohio State | 0.9866 | 2-0
4 | Texas | 0.9842 | 3-0
5 | Missouri | 0.9782 | 3-0
6 | Mississippi | 0.9771 | 3-0
7 | Oregon | 0.9632 | 3-0
8 | Penn State | 0.9603 | 2-0
9 | Oklahoma | 0.9427 | 3-0
10 | Tennessee | 0.9379 | 3-0
11 | Kansas State | 0.9376 | 3-0
12 | Louisville | 0.9373 | 2-0
13 | Oklahoma State | 0.9215 | 3-0
14 | Miami FL | 0.9161 | 3-0
15 | USC | 0.9134 | 2-0
16 | Utah | 0.9131 | 3-0
17 | Duke | 0.9113 | 3-0
18 | Iowa State | 0.9107 | 2-0
19 | Rutgers | 0.9068 | 2-0
20 | James Madison | 0.9001 | 2-0
21 | North Carolina | 0.8916 | 3-0
22 | Liberty | 0.8905 | 3-0
23 | Memphis | 0.8847 | 3-0
24 | California | 0.8815 | 3-0
25 | Michigan State | 0.8759 | 3-0

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/2024-Week%2004.md)

#### Observations and Notes (Updated 9/15/2024)

* Looking much better than the last couple weeks. The effects of the preseason adjustments are extremely small now compared to the previous polls. Still my #1 takeaway for the offseason is adjusting the early season adjustments.
* Noticed I forgot to remove the Big 10 divisions from my list of teams. Doesn't effect anything but whoops lol.

#### Predictions (Updated 9/15/2024)

Week 4 Predictions: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2004.md)

Week 3 Results: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2003.md)

Week 3 Results:
* Winner: 36 - 15 (70.6%)
* ATS: 16 - 35 (31.4%)
* O/U: 26 - 25 (51.0%)

Season Results:
* Winner: 67 - 33 (67.0%)
* ATS: 41 - 59 (41.0%)
* O/U: 52 - 48 (52.0%)

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
