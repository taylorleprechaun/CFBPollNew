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

### Rankings (Updated 1/12/2025)

**Week 17 Rankings**

Rank | Team | Rating | Record | SoS | SoS Rank
---|---|---|---|---|---
1 | Oregon | 1.0000 | 13-1 | 0.5917 | 17
2 | Ohio State | 0.9847 | 13-2 | 0.6119 | 8
3 | Notre Dame | 0.9821 | 14-1 | 0.5844 | 25
4 | Texas | 0.9364 | 13-3 | 0.5931 | 16
5 | Penn State | 0.9287 | 13-3 | 0.5816 | 28
6 | Georgia | 0.9250 | 11-3 | 0.6048 | 9
7 | Indiana | 0.9136 | 11-2 | 0.5318 | 80
8 | Boise State | 0.9025 | 12-2 | 0.5458 | 67
9 | Brigham Young | 0.9005 | 11-2 | 0.5261 | 84
10 | Iowa State | 0.8870 | 11-3 | 0.5553 | 57
11 | SMU | 0.8866 | 11-3 | 0.5546 | 61
12 | Syracuse | 0.8803 | 10-3 | 0.5635 | 40
13 | Mississippi | 0.8796 | 10-3 | 0.5448 | 68
14 | Illinois | 0.8773 | 10-3 | 0.5578 | 52
15 | Arizona State | 0.8746 | 11-3 | 0.5349 | 78
16 | Miami FL | 0.8741 | 10-3 | 0.5443 | 69
17 | Alabama | 0.8701 | 9-4 | 0.5954 | 14
18 | Missouri | 0.8643 | 10-3 | 0.5380 | 76
19 | South Carolina | 0.8625 | 9-4 | 0.5902 | 18
20 | Tennessee | 0.8593 | 10-3 | 0.5258 | 85
21 | Louisville | 0.8572 | 9-4 | 0.5819 | 27
22 | Louisiana State | 0.8534 | 9-4 | 0.5851 | 23
23 | Clemson | 0.8533 | 10-4 | 0.5580 | 51
24 | Army | 0.8510 | 12-2 | 0.4986 | 114
25 | Navy | 0.8429 | 10-3 | 0.5551 | 60

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/2024-Week%2017%20NCG.md)

#### Observations and Notes (Updated 1/12/2025)

* It looks like regardless of the result of the national championship game my poll is going to rank Oregon #1. I spent some time playing with plugging in hypothetical winners/losers and Oregon stays on top just barely. If you've read my BOAT/WOAT section you'll know that the top teams in my poll have a rating over 40 and no one this season is over that rating (Oregon is currently closest at 39.818). The poll doesn't perceive any team as "elite" and Oregon just happens to be the best of a bunch of "great" teams.

#### Predictions (Updated 1/12/2025)

National Championship Prediction: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2017%20NCG.md)

Bowls + Playoff Rounds 1-3 Results: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2016%20Bowls.md)

Results:
* Winner: 30 - 16 (65.2%)
* ATS: 21 - 25 (45.7%)
* O/U: 22 - 24 (47.8%)

Season Results:
* Winner: 509 - 238 (68.1%)
* ATS: 364 - 393 (48.1%)
* O/U: 373 - 384 (49.3%)

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
