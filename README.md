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

### Rankings (Updated 12/8/2024)

**Week 16 Rankings**

Rank | Team | Rating | Record | SoS | SoS Rank
---|---|---|---|---|---
1 | Oregon | 1.0000 | 13-0 | 0.5628 | 40
2 | Georgia | 0.9269 | 11-2 | 0.5858 | 19
3 | Notre Dame | 0.9188 | 11-1 | 0.5348 | 69
4 | Ohio State | 0.9178 | 10-2 | 0.5734 | 30
5 | Texas | 0.9159 | 11-2 | 0.5620 | 42
6 | Boise State | 0.9133 | 12-1 | 0.5322 | 72
7 | Indiana | 0.9030 | 11-1 | 0.4879 | 117
8 | SMU | 0.8962 | 11-2 | 0.5435 | 63
9 | Alabama | 0.8885 | 9-3 | 0.5977 | 12
10 | Penn State | 0.8874 | 11-2 | 0.5281 | 75
11 | Miami FL | 0.8846 | 10-2 | 0.5316 | 73
12 | Arizona State | 0.8731 | 11-2 | 0.5100 | 94
13 | South Carolina | 0.8728 | 9-3 | 0.5836 | 22
14 | Brigham Young | 0.8723 | 10-2 | 0.5202 | 86
15 | Clemson | 0.8649 | 10-3 | 0.5539 | 52
16 | Syracuse | 0.8618 | 9-3 | 0.5764 | 27
17 | Tennessee | 0.8595 | 10-2 | 0.4992 | 107
18 | Iowa State | 0.8559 | 10-3 | 0.5496 | 55
19 | Army | 0.8513 | 11-1 | 0.4745 | 124
20 | Mississippi | 0.8470 | 9-3 | 0.5387 | 67
21 | Louisville | 0.8408 | 8-4 | 0.6000 | 11
22 | Illinois | 0.8371 | 9-3 | 0.5400 | 66
23 | Missouri | 0.8368 | 9-3 | 0.5383 | 68
24 | UNLV | 0.8239 | 10-3 | 0.5233 | 81
25 | Duke | 0.8238 | 9-3 | 0.5224 | 84

Full Rankings: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/2024-Week%2016%20CCG.md)

**Playoff Teams**

Seed | Rank | Team | Record
---|---|---|---
1 | 1 | Oregon* | 13-0
2 | 2 | Georgia* | 11-2
3 | 6 | Boise State* | 12-1
4 | 12 | Arizona State* | 11-2
5 | 3 | Notre Dame | 11-1
6 | 4 | Ohio State | 10-2
7 | 5 | Texas | 11-2
8 | 7 | Indiana | 11-1
9 | 8 | SMU | 11-2
10 | 9 | Alabama | 9-3
11 | 10 | Penn State | 11-2
12 | 15 | Clemson* | 10-3

#### Observations and Notes (Updated 12/8/2024)

* Well here we are with the field set. Would be an odd year for sure to have a 4 team playoff. The candidates for it all feel flawed in ways that they haven't been in the past and my ranking even shows this under the hood. My poll basically only considers Oregon as an elite team and just barely with the rest of the field trailing way far behind. The gap between #1 Oregon and #2 Georgia is nearly the same as the gap between #2 Georgia and #19 Army.
* Speaking of the field being set, The bracket for this one looks pretty good. Don't like Bama being in there but when you reward strength of schedule like my poll does you're going to get a boost from it above teams with better records (on paper).
* And as a last little note here, I'm not a huge fan of the 12-team system and would have preferred either 8 or 16 and I have a lot of opinions on how those would have worked. I won't ramble on about it but if you're reading this and want my thoughts just shoot me a message on twitter, reddit, etc.

#### Predictions (Updated 12/28/2024)

Bowl Predictions (+ Army/Navy) (+Playoff Round 2): [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2016%20Bowls.md)

Week 15 CCG Results: [here](https://github.com/taylorleprechaun/CFBPollNew/blob/main/CFBPoll/PreviousPolls/2024/Predictions/2024-Week%2015%20CCG.md)

Results:
* Winner: 5 - 4 (55.6%)
* ATS: 4 - 5 (44.4%)
* O/U: 5 - 4 (55.6%)

Season Results:
* Winner: 479 - 222 (68.3%)
* ATS: 343 - 368 (48.2%)
* O/U: 351 - 360 (49.4%)

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
